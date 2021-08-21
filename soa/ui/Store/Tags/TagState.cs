using System;
using System.Collections.Generic;
using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags
{
  public class TagState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<TagDto> TagList { get; private set; }
    public TagDto Tag { get; private set; }
    public TagForCreationDto TagToBeCreatedPayload { get; private set; }
    public TagForModificationDto TagToBeUpdatePayload { get; }
    public Guid TagId { get; }

    public TagState(
      List<TagDto> tagList, 
      string errorMessage, 
      bool isLoading,
      TagDto tag, 
      TagForCreationDto tagToBeCreatedPayload, 
      TagForModificationDto tagToBeUpdatePayload, 
      Guid tagId
    )
    {
      TagList  = tagList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Tag = tag;
      TagToBeCreatedPayload = tagToBeCreatedPayload;
      TagToBeUpdatePayload = tagToBeUpdatePayload;
      TagId = tagId;
    }
  }
}