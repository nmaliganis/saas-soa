using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.api.Controllers.API.Base;
using soa.api.Validators;
using soa.common.infrastructure.PropertyMappings;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.common.infrastructure.Vms.Answers;
using soa.contracts.Answers;
using soa.contracts.V1;

namespace soa.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class AnswersController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllAnswersProcessor _inquiryAllAnswersProcessor;
    private readonly IInquiryAnswerProcessor _inquiryAnswerProcessor;
    private readonly ICreateAnswerProcessor _createAnswerProcessor;
    private readonly IUpdateAnswerProcessor _updateAnswerProcessor;
    private readonly IDeleteAnswerProcessor _deleteAnswerProcessor;

    public AnswersController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IAnswersControllerDependencyBlock blockAnswer)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;

      _inquiryAllAnswersProcessor = blockAnswer.InquiryAllAnswersProcessor;
      _inquiryAnswerProcessor = blockAnswer.InquiryAnswerProcessor;
      _createAnswerProcessor = blockAnswer.CreateAnswerProcessor;
      _updateAnswerProcessor = blockAnswer.UpdateAnswerProcessor;
      _deleteAnswerProcessor = blockAnswer.DeleteAnswerProcessor;
    }

    /// <summary>
    /// POST : Create a New Answer.
    /// </summary>
    /// <param name="AnswerForCreationDto">AnswerForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Answer is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Answer is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostAnswerRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostAnswerRouteAsync([FromBody] AnswerForCreationUiModel AnswerForCreationDto)
    {
      var newCreatedAnswer = await _createAnswerProcessor.CreateAnswerAsync(AnswerForCreationDto);

      switch (newCreatedAnswer.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostAnswerRouteAsync -- Message:Answer_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- AnswerInfo:{AnswerForCreationDto.Title}");
          return Created(nameof(PostAnswerRouteAsync), newCreatedAnswer);
        }
        case ("ERROR_Answer_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostAnswerRouteAsync -- Message:ERROR_Answer_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- AnswerInfo:{AnswerForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Answer_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_Answer_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostAnswerRouteAsync -- Message:ERROR_Answer_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- AnswerInfo:{AnswerForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Answer_ALREADY_EXISTS"});
        }
        case ("ERROR_Answer_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostAnswerRouteAsync -- Message:ERROR_Answer_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- AnswerInfo:{AnswerForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Answer"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostAnswerRouteAsync -- Message:ERROR_CREATION_NEW_Answer -- Datetime:{DateTime.UtcNow} " +
            $"-- AnswerInfo:{AnswerForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Answer"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Answer Id
    /// </summary>
    /// <param name="id">Answer Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Answer</param>
    /// <remarks>Retrieve Answer Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetAnswer")]
    public async Task<IActionResult> GetAnswerAsync(int id)
    {
      var answerFromRepo = await _inquiryAnswerProcessor.GetAnswerByIdAsync(id);

      if (answerFromRepo == null)
      {
        return NotFound();
      }

      var answer = Mapper.Map<AnswerUiModel>(answerFromRepo);

      return Ok(answer);
    }

    /// <summary>
    /// PUT : Update Answer with New Answer Name
    /// </summary>
    /// <param name="id">Answer Id the Request Index for Retrieval</param>
    /// <param name="updatedAnswer">AnswerForModification the Request Model with New Answer Name</param>
    /// <remarks>Change Answer providing AnswerForModificationUiModel with Modified Answer Name</remarks>
    /// <response code="200">Resource updated correctly.</response>
    /// <response code="400">The model is not in valid state.</response>
    /// <response code="403">You have not access for this action.</response>
    /// <response code="404">Wrong attributes provided.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpPut("{id}", Name = "UpdateAnswerRoot")]
    [ValidateModel]
    public async Task<IActionResult> UpdateAnswerAsync(int id, [FromBody] AnswerForModificationUiModel updatedAnswer)
    {
      if (id == 0 || String.IsNullOrEmpty(updatedAnswer.Title))
        return BadRequest();

      await _updateAnswerProcessor.UpdateAnswerAsync(id, updatedAnswer);

      return Ok(await _inquiryAnswerProcessor.GetAnswerByIdAsync(id));
    }

    /// <summary>
    /// Delete - Delete an existing Answer 
    /// </summary>
    /// <param name="id">Answer Id for Deletion</param>
    /// <remarks>Delete Existing Answer </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeleteAnswerRoot")]
    public async Task<IActionResult> DeleteAnswerRoot(int id)
    {
      //var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      //if (userAudit == null)
      //  return BadRequest();

      //var AnswerToBeSoftDeleted = await _deleteAnswerProcessor.SoftDeleteAnswerAsync(userAudit.Id, id);

      //return Ok(AnswerToBeSoftDeleted);
      return Ok();
    }

    /// <summary>
    /// Delete - Delete an existing Answer 
    /// </summary>
    /// <param name="id">Answer Id for Deletion</param>
    /// <remarks>Delete Existing Answer </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardAnswerRoot")]
    [Authorize]
    public async Task<IActionResult> DeleteHardAnswerRoot(int id)
    {
      var answerToBeDeleted = await _deleteAnswerProcessor.HardDeleteAnswerAsync(id);

      return Ok(answerToBeDeleted);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Answers 
    /// </summary>
    /// <remarks>Retrieve paged Answers providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetAnswers")]
    public async Task<IActionResult> GetAnswersAsync()
    {
      var answersQueryable =
        await _inquiryAllAnswersProcessor.GetAnswersAsync();

      var answers = Mapper.Map<IEnumerable<AnswerUiModel>>(answersQueryable);

      return Ok(answers);
    }
  }
}
