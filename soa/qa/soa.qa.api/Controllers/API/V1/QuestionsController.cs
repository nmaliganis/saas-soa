using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.api.Validators;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.qa.api.Controllers.API.Base;
using soa.qa.contracts.Questions;
using soa.qa.contracts.V1;

namespace soa.qa.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class QuestionsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllQuestionsProcessor _inquiryAllQuestionsProcessor;
    private readonly IInquiryQuestionProcessor _inquiryQuestionProcessor;
    private readonly ICreateQuestionProcessor _createQuestionProcessor;
    private readonly IUpdateQuestionProcessor _updateQuestionProcessor;
    private readonly IDeleteQuestionProcessor _deleteQuestionProcessor;

    public QuestionsController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IQuestionsControllerDependencyBlock blockQuestion)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;
      _inquiryAllQuestionsProcessor = blockQuestion.InquiryAllQuestionsProcessor;
      _inquiryQuestionProcessor = blockQuestion.InquiryQuestionProcessor;
      _createQuestionProcessor = blockQuestion.CreateQuestionProcessor;
      _updateQuestionProcessor = blockQuestion.UpdateQuestionProcessor;
      _deleteQuestionProcessor = blockQuestion.DeleteQuestionProcessor;
    }

    /// <summary>
    /// POST : Create a New Question.
    /// </summary>
    /// <param name="questionForCreationDto">QuestionForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Question is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Question is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostQuestionRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostQuestionRouteAsync([FromBody] QuestionForCreationUiModel questionForCreationDto)
    {
      var newCreatedQuestion = await _createQuestionProcessor.CreateQuestionAsync(questionForCreationDto);

      switch (newCreatedQuestion.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostQuestionRouteAsync -- Message:Question_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- QuestionInfo:{questionForCreationDto.Title}");
          return Created(nameof(PostQuestionRouteAsync), newCreatedQuestion);
        }
        case ("ERROR_Question_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostQuestionRouteAsync -- Message:ERROR_Question_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- QuestionInfo:{questionForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Question_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_Question_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostQuestionRouteAsync -- Message:ERROR_Question_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- QuestionInfo:{questionForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Question_ALREADY_EXISTS"});
        }
        case ("ERROR_Question_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostQuestionRouteAsync -- Message:ERROR_Question_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- QuestionInfo:{questionForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Question"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostQuestionRouteAsync -- Message:ERROR_CREATION_NEW_Question -- Datetime:{DateTime.UtcNow} " +
            $"-- QuestionInfo:{questionForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Question"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Question Id
    /// </summary>
    /// <param name="id">Question Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Question</param>
    /// <remarks>Retrieve Question Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetQuestion")]
    public async Task<IActionResult> GetQuestionAsync(int id)
    {
      var questionFromRepo = await _inquiryQuestionProcessor.GetQuestionByIdAsync(id);

      if (questionFromRepo == null)
      {
        return NotFound();
      }

      var question = Mapper.Map<QuestionUiModel>(questionFromRepo);

      return Ok(question);
    }

    /// <summary>
    /// PUT : Update Question with New Question Name
    /// </summary>
    /// <param name="id">Question Id the Request Index for Retrieval</param>
    /// <param name="updatedQuestion">QuestionForModification the Request Model with New Question Name</param>
    /// <remarks>Change Question providing QuestionForModificationUiModel with Modified Question Name</remarks>
    /// <response code="200">Resource updated correctly.</response>
    /// <response code="400">The model is not in valid state.</response>
    /// <response code="403">You have not access for this action.</response>
    /// <response code="404">Wrong attributes provided.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpPut("{id}", Name = "UpdateQuestionRoot")]
    [ValidateModel]
    public async Task<IActionResult> UpdateQuestionAsync(int id, [FromBody] QuestionForModificationUiModel updatedQuestion)
    {
      if (id == 0 || String.IsNullOrEmpty(updatedQuestion.Title))
        return BadRequest();

      await _updateQuestionProcessor.UpdateQuestionAsync(id, updatedQuestion);

      return Ok(await _inquiryQuestionProcessor.GetQuestionByIdAsync(id));
    }

    /// <summary>
    /// Delete - Delete an existing Question 
    /// </summary>
    /// <param name="id">Question Id for Deletion</param>
    /// <remarks>Delete Existing Question </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeleteQuestionRoot")]
    public async Task<IActionResult> DeleteQuestionRoot(int id)
    {
      //var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      //if (userAudit == null)
      //  return BadRequest();

      //var QuestionToBeSoftDeleted = await _deleteQuestionProcessor.SoftDeleteQuestionAsync(userAudit.Id, id);

      //return Ok(QuestionToBeSoftDeleted);
      return Ok();
    }

    /// <summary>
    /// Delete - Delete an existing Question 
    /// </summary>
    /// <param name="id">Question Id for Deletion</param>
    /// <remarks>Delete Existing Question </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardQuestionRoot")]
    [Authorize]
    public async Task<IActionResult> DeleteHardQuestionRoot(int id)
    {
      var questionToBeDeleted = await _deleteQuestionProcessor.HardDeleteQuestionAsync(id);

      return Ok(questionToBeDeleted);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Questions 
    /// </summary>
    /// <remarks>Retrieve paged Questions providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetQuestions")]
    public async Task<IActionResult> GetQuestionsAsync()
    {
      var questionsQueryable =
        await _inquiryAllQuestionsProcessor.GetQuestionsAsync();

      return Ok(questionsQueryable);
    }
  }
}
