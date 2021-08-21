using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.api.Validators;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.qa.api.Controllers.API.Base;
using soa.qa.contracts.Tags;
using soa.qa.contracts.V1;

namespace soa.qa.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class TagsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllTagsProcessor _inquiryAllTagsProcessor;
    private readonly IInquiryTagProcessor _inquiryTagProcessor;
    private readonly ICreateTagProcessor _createTagProcessor;
    private readonly IUpdateTagProcessor _updateTagProcessor;
    private readonly IDeleteTagProcessor _deleteTagProcessor;

    public TagsController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      ITagsControllerDependencyBlock blockTag)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;

      _inquiryAllTagsProcessor = blockTag.InquiryAllTagsProcessor;
      _inquiryTagProcessor = blockTag.InquiryTagProcessor;
      _createTagProcessor = blockTag.CreateTagProcessor;
      _updateTagProcessor = blockTag.UpdateTagProcessor;
      _deleteTagProcessor = blockTag.DeleteTagProcessor;
    }

    /// <summary>
    /// POST : Create a New Tag.
    /// </summary>
    /// <param name="tagForCreationDto">TagForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Tag is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Tag is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostTagRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostTagRouteAsync([FromBody] TagForCreationUiModel tagForCreationDto)
    {
      var newCreatedTag = await _createTagProcessor.CreateTagAsync(tagForCreationDto);

      switch (newCreatedTag.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostTagRouteAsync -- Message:Tag_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- TagInfo:{tagForCreationDto.Title}");
          return Created(nameof(PostTagRouteAsync), newCreatedTag);
        }
        case ("ERROR_Tag_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostTagRouteAsync -- Message:ERROR_Tag_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- TagInfo:{tagForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Tag_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_Tag_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostTagRouteAsync -- Message:ERROR_Tag_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- TagInfo:{tagForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Tag_ALREADY_EXISTS"});
        }
        case ("ERROR_Tag_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostTagRouteAsync -- Message:ERROR_Tag_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- TagInfo:{tagForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Tag"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostTagRouteAsync -- Message:ERROR_CREATION_NEW_Tag -- Datetime:{DateTime.UtcNow} " +
            $"-- TagInfo:{tagForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Tag"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Tag Id
    /// </summary>
    /// <param name="id">Tag Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Tag</param>
    /// <remarks>Retrieve Tag Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetTag")]
    public async Task<IActionResult> GetTagAsync(int id)
    {
      var tagFromRepo = await _inquiryTagProcessor.GetTagByIdAsync(id);

      if (tagFromRepo == null)
      {
        return NotFound();
      }

      var tag = Mapper.Map<TagUiModel>(tagFromRepo);

      return Ok(tag);
    }

    /// <summary>
    /// PUT : Update Tag with New Tag Name
    /// </summary>
    /// <param name="id">Tag Id the Request Index for Retrieval</param>
    /// <param name="updatedTag">TagForModification the Request Model with New Tag Name</param>
    /// <remarks>Change Tag providing TagForModificationUiModel with Modified Tag Name</remarks>
    /// <response code="200">Resource updated correctly.</response>
    /// <response code="400">The model is not in valid state.</response>
    /// <response code="403">You have not access for this action.</response>
    /// <response code="404">Wrong attributes provided.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpPut("{id}", Name = "UpdateTagRoot")]
    [ValidateModel]
    public async Task<IActionResult> UpdateTagAsync(int id, [FromBody] TagForModificationUiModel updatedTag)
    {
      if (id == 0 || String.IsNullOrEmpty(updatedTag.Title))
        return BadRequest();

      await _updateTagProcessor.UpdateTagAsync(id, updatedTag);

      return Ok(await _inquiryTagProcessor.GetTagByIdAsync(id));
    }

    /// <summary>
    /// Delete - Delete an existing Tag 
    /// </summary>
    /// <param name="id">Tag Id for Deletion</param>
    /// <remarks>Delete Existing Tag </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeleteTagRoot")]
    public async Task<IActionResult> DeleteTagRoot(Guid id)
    {
      //var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      //if (userAudit == null)
      //  return BadRequest();

      //var TagToBeSoftDeleted = await _deleteTagProcessor.SoftDeleteTagAsync(userAudit.Id, id);

      //return Ok(TagToBeSoftDeleted);
      return Ok();
    }

    /// <summary>
    /// Delete - Delete an existing Tag 
    /// </summary>
    /// <param name="id">Tag Id for Deletion</param>
    /// <remarks>Delete Existing Tag </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardTagRoot")]
    [Authorize]
    public async Task<IActionResult> DeleteHardTagRoot(int id)
    {
      var tagToBeDeleted = await _deleteTagProcessor.HardDeleteTagAsync(id);

      return Ok(tagToBeDeleted);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Tags 
    /// </summary>
    /// <remarks>Retrieve paged Tags providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetTags")]
    public async Task<IActionResult> GetTagsAsync()
    {
      var tagsQueryable =
        await _inquiryAllTagsProcessor.GetTagsAsync();

      var tags = Mapper.Map<IEnumerable<TagUiModel>>(tagsQueryable);

      return Ok(tags);
    }
  }
}
