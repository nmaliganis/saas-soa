using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.api.Validators;
using soa.common.dtos.Vms.Categories;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.qa.api.Controllers.API.Base;
using soa.qa.contracts.Categories;
using soa.qa.contracts.V1;

namespace soa.qa.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class CategoriesController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllCategoriesProcessor _inquiryAllCategoriesProcessor;
    private readonly IInquiryCategoryProcessor _inquiryCategoryProcessor;
    private readonly ICreateCategoryProcessor _createCategoryProcessor;
    private readonly IUpdateCategoryProcessor _updateCategoryProcessor;
    private readonly IDeleteCategoryProcessor _deleteCategoryProcessor;

    public CategoriesController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      ICategoriesControllerDependencyBlock blockCategory)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;

      _inquiryAllCategoriesProcessor = blockCategory.InquiryAllCategoriesProcessor;
      _inquiryCategoryProcessor = blockCategory.InquiryCategoryProcessor;
      _createCategoryProcessor = blockCategory.CreateCategoryProcessor;
      _updateCategoryProcessor = blockCategory.UpdateCategoryProcessor;
      _deleteCategoryProcessor = blockCategory.DeleteCategoryProcessor;
    }

    /// <summary>
    /// POST : Create a New Category.
    /// </summary>
    /// <param name="categoryForCreationDto">CategoryForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Category is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Category is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostCategoryRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostCategoryRouteAsync([FromBody] CategoryForCreationUiModel categoryForCreationDto)
    {
      var newCreatedCategory = await _createCategoryProcessor.CreateCategoryAsync(categoryForCreationDto);

      switch (newCreatedCategory.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostCategoryRouteAsync -- Message:Category_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- CategoryInfo:{categoryForCreationDto.Name}");
          return Created(nameof(PostCategoryRouteAsync), newCreatedCategory);
        }
        case ("ERROR_Category_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_Category_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- CategoryInfo:{categoryForCreationDto.Name}");
          return BadRequest(new {errorMessage = "Category_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_Category_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_Category_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- CategoryInfo:{categoryForCreationDto.Name}");
          return BadRequest(new {errorMessage = "Category_ALREADY_EXISTS"});
        }
        case ("ERROR_Category_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_Category_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- CategoryInfo:{categoryForCreationDto.Name}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Category"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostCategoryRouteAsync -- Message:ERROR_CREATION_NEW_Category -- Datetime:{DateTime.UtcNow} " +
            $"-- CategoryInfo:{categoryForCreationDto.Name}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Category"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Category Id
    /// </summary>
    /// <param name="id">Category Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Category</param>
    /// <remarks>Retrieve Category Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<IActionResult> GetCategoryAsync(int id)
    {
      var categoryFromRepo = await _inquiryCategoryProcessor.GetCategoryByIdAsync(id);

      if (categoryFromRepo == null)
      {
        return NotFound();
      }

      var category = Mapper.Map<CategoryUiModel>(categoryFromRepo);

      return Ok(category);
    }

    /// <summary>
    /// PUT : Update Category with New Category Name
    /// </summary>
    /// <param name="id">Category Id the Request Index for Retrieval</param>
    /// <param name="updatedCategory">CategoryForModification the Request Model with New Category Name</param>
    /// <remarks>Change Category providing CategoryForModificationUiModel with Modified Category Name</remarks>
    /// <response code="200">Resource updated correctly.</response>
    /// <response code="400">The model is not in valid state.</response>
    /// <response code="403">You have not access for this action.</response>
    /// <response code="404">Wrong attributes provided.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpPut("{id}", Name = "UpdateCategoryRoot")]
    [ValidateModel]
    public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryForModificationUiModel updatedCategory)
    {
      if (id == 0 || String.IsNullOrEmpty(updatedCategory.Name))
        return BadRequest();

      await _updateCategoryProcessor.UpdateCategoryAsync(id, updatedCategory);

      return Ok(await _inquiryCategoryProcessor.GetCategoryByIdAsync(id));
    }

    /// <summary>
    /// Delete - Delete an existing Category 
    /// </summary>
    /// <param name="id">Category Id for Deletion</param>
    /// <remarks>Delete Existing Category </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("{id}", Name = "DeleteCategoryRoot")]
    public async Task<IActionResult> DeleteCategoryRoot(int id)
    {
      //var userAudit = await _inquiryUserProcessor.GetUserByLoginAsync(GetEmailFromClaims());

      //if (userAudit == null)
      //  return BadRequest();

      //var CategoryToBeSoftDeleted = await _deleteCategoryProcessor.SoftDeleteCategoryAsync(userAudit.Id, id);

      //return Ok(CategoryToBeSoftDeleted);
      return Ok();
    }

    /// <summary>
    /// Delete - Delete an existing Category 
    /// </summary>
    /// <param name="id">Category Id for Deletion</param>
    /// <remarks>Delete Existing Category </remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpDelete("hard/{id}", Name = "DeleteHardCategoryRoot")]
    [Authorize]
    public async Task<IActionResult> DeleteHardCategoryRoot(int id)
    {
      var categoryToBeDeleted = await _deleteCategoryProcessor.HardDeleteCategoryAsync(id);

      return Ok(categoryToBeDeleted);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Categories 
    /// </summary>
    /// <remarks>Retrieve paged Categories providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetCategories")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
      var categoriesQueryable =
        await _inquiryAllCategoriesProcessor.GetCategoriesAsync();

      return Ok(categoriesQueryable);
    }
  }
}
