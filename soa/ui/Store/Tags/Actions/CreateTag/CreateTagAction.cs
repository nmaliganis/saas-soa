using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags.Actions.CreateTag
{
  public class CreateTagAction
  {
    public CreateTagAction(TagForCreationDto tagToBeCreatedPayload)
    {
      TagToBeCreatedPayload = tagToBeCreatedPayload;
    }

    public TagForCreationDto TagToBeCreatedPayload { get; private set; }
  }
}