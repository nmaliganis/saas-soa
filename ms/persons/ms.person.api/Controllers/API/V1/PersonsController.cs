using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.api.Validators;
using soa.common.dtos.Vms.Persons;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.qa.api.Controllers.API.Base;
using soa.qa.contracts.Persons;
using soa.qa.contracts.V1;

namespace soa.qa.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class PersonsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllPersonsProcessor _inquiryAllPersonsProcessor;
    private readonly IInquiryPersonProcessor _inquiryPersonProcessor;
    private readonly ICreatePersonProcessor _createPersonProcessor;
    private readonly IUpdatePersonProcessor _updatePersonProcessor;
    private readonly IDeletePersonProcessor _deletePersonProcessor;

    public PersonsController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IPersonsControllerDependencyBlock blockPerson)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;

      _inquiryAllPersonsProcessor = blockPerson.InquiryAllPersonsProcessor;
      _inquiryPersonProcessor = blockPerson.InquiryPersonProcessor;
      _createPersonProcessor = blockPerson.CreatePersonProcessor;
      _updatePersonProcessor = blockPerson.UpdatePersonProcessor;
      _deletePersonProcessor = blockPerson.DeletePersonProcessor;
    }

    /// <summary>
    /// POST : Create a New Person.
    /// </summary>
    /// <param name="personForCreationDto">PersonForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Person is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Person is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostPersonRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostPersonRouteAsync([FromBody] PersonForCreationUiModel personForCreationDto)
    {
      var newCreatedPerson = await _createPersonProcessor.CreatePersonAsync(personForCreationDto);

      switch (newCreatedPerson.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostPersonRouteAsync -- Message:PERSON_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- PersonInfo:{personForCreationDto.Email}");
          return Created(nameof(PostPersonRouteAsync), newCreatedPerson);
        }
        case ("ERROR_PERSON_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostPersonRouteAsync -- Message:ERROR_PERSON_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- PersonInfo:{personForCreationDto.Email}");
          return BadRequest(new {errorMessage = "PERSON_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_PERSON_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostPersonRouteAsync -- Message:ERROR_PERSON_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- PersonInfo:{personForCreationDto.Email}");
          return BadRequest(new {errorMessage = "PERSON_ALREADY_EXISTS"});
        }
        case ("ERROR_PERSON_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostPersonRouteAsync -- Message:ERROR_PERSON_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- PersonInfo:{personForCreationDto.Email}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_PERSON"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostPersonRouteAsync -- Message:ERROR_CREATION_NEW_PERSON -- Datetime:{DateTime.UtcNow} " +
            $"-- PersonInfo:{personForCreationDto.Email}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_PERSON"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Person Id
    /// </summary>
    /// <param name="id">Person Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Person</param>
    /// <remarks>Retrieve Person Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetPerson")]
    public async Task<IActionResult> GetPersonAsync(int id)
    {
      var personFromRepo = await _inquiryPersonProcessor.GetPersonByIdAsync(id);

      if (personFromRepo == null)
      {
        return NotFound();
      }

      var person = Mapper.Map<PersonUiModel>(personFromRepo);

      return Ok(person);
    }

    /// <summary>
    /// PUT : Update Person with New Person Name
    /// </summary>
    /// <param name="id">Person Id the Request Index for Retrieval</param>
    /// <param name="updatedPerson">PersonForModification the Request Model with New Person Name</param>
    /// <remarks>Change Person providing PersonForModificationUiModel with Modified Person Name</remarks>
    /// <response code="200">Resource updated correctly.</response>
    /// <response code="400">The model is not in valid state.</response>
    /// <response code="403">You have not access for this action.</response>
    /// <response code="404">Wrong attributes provided.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpPut("{id}", Name = "UpdatePersonRoot")]
    [ValidateModel]
    public async Task<IActionResult> UpdatePersonAsync(int id, [FromBody] PersonForModificationUiModel updatedPerson)
    {
      if (id == 0 || String.IsNullOrEmpty(updatedPerson.Email))
        return BadRequest();

      await _updatePersonProcessor.UpdatePersonAsync(id, updatedPerson);

      return Ok(await _inquiryPersonProcessor.GetPersonByIdAsync(id));
    }

    /// <summary>
    /// Delete - Delete an existing Person 
    /// </summary>
    /// <param name="id">Person Id for Deletion</param>
    /// <remarks>Delete Existing Person </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeletePersonRoot")]
    public async Task<IActionResult> DeletePersonRoot(int id)
    {
      //var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      //if (userAudit == null)
      //  return BadRequest();

      //var PersonToBeSoftDeleted = await _deletePersonProcessor.SoftDeletePersonAsync(userAudit.Id, id);

      //return Ok(PersonToBeSoftDeleted);
      return Ok();
    }

    /// <summary>
    /// Delete - Delete an existing Person 
    /// </summary>
    /// <param name="id">Person Id for Deletion</param>
    /// <remarks>Delete Existing Person </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardPersonRoot")]
    [Authorize]
    public async Task<IActionResult> DeleteHardPersonRoot(int id)
    {
      var personToBeDeleted = await _deletePersonProcessor.HardDeletePersonAsync(id);

      return Ok(personToBeDeleted);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Persons 
    /// </summary>
    /// <remarks>Retrieve paged Persons providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetPersons")]
    public async Task<IActionResult> GetPersonsAsync()
    {
      var personsQueryable =
        await _inquiryAllPersonsProcessor.GetPersonsAsync();

      var persons = Mapper.Map<IEnumerable<PersonUiModel>>(personsQueryable);

      return Ok(persons);
    }
  }
}
