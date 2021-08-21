using System;
using System.Collections.Generic;
using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories
{
  public class CategoryState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<CategoryDto> CategoryList { get; private set; }
    public CategoryDto Category { get; private set; }
    public CategoryForCreationDto CategoryToBeCreatedPayload { get; private set; }
    public CategoryForModificationDto CategoryToBeUpdatePayload { get; }
    public Guid CategoryId { get; }

    public CategoryState(
      List<CategoryDto> categoryList, 
      string errorMessage, 
      bool isLoading,
      CategoryDto category, 
      CategoryForCreationDto categoryToBeCreatedPayload, 
      CategoryForModificationDto categoryToBeUpdatePayload, 
      Guid categoryId
    )
    {
      CategoryList  = categoryList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Category = category;
      CategoryToBeCreatedPayload = categoryToBeCreatedPayload;
      CategoryToBeUpdatePayload = categoryToBeUpdatePayload;
      CategoryId = categoryId;
    }
  }
}