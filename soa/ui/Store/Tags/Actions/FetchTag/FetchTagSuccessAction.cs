using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags.Actions.FetchTag
{
  public class FetchTagSuccessAction
  {
    public TagDto TagToHaveBeenFetched { get; private set; }

    public FetchTagSuccessAction(TagDto tagToHaveBeenFetched)
    {
      TagToHaveBeenFetched  = tagToHaveBeenFetched;
    }
  }
}