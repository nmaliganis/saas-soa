using Fluxor;
using soa.ui.Store.Tags.Actions.FetchTags;

namespace soa.ui.Store.Tags.Reducers.FetchTags
{
  public class FetchTagListReducer : Reducer<TagState, FetchTagListAction>
  {
    public override TagState Reduce(TagState state, FetchTagListAction action)
    {
      return new TagState(
        state.TagList,
        "",
        state.IsLoading,
        state.Tag,
        state.TagToBeCreatedPayload,
        state.TagToBeUpdatePayload,
        state.TagId
        );
    }
  }
}