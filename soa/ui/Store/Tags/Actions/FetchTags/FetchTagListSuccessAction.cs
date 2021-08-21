using System.Collections.Generic;
using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags.Actions.FetchTags
{
  public class FetchTagListSuccessAction
  {
    public List<TagDto> TagList { get; private set; }

    public FetchTagListSuccessAction(List<TagDto> tagList)
    {
      TagList  = tagList;
    }
  }
}