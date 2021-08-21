using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags.Actions.CreateTag
{
  public class CreateTagSuccessAction
  {
    public TagDto TagHaveBeenCreated { get; private set; }

    public CreateTagSuccessAction(TagDto tagHaveBeenCreated)
    {
      TagHaveBeenCreated = tagHaveBeenCreated;
    }
  }
}