using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Services.Contracts.Categories
{
  public interface ICategoryDataService
  {
    Task<List<CategoryDto>> GetCategoryList(string authorizationToken = null);
    Task<CategoryDto> GetCategory(int actionCategoryId);
    Task<int> GetTotalCategoryCount();

    Task<CategoryDto> CreateCategory(CategoryForCreationDto categoryToBeCreated);
    Task<CategoryDto> UpdateCategory(Guid categoryIdToBeUpdated, CategoryForModificationDto categoryToBeUpdated);
    Task<CategoryDto> DeleteCategory(Guid categoryIdToBeDeleted);
  }
}