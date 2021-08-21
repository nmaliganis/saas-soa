using Fluxor;
using soa.ui.Store.Tags.Actions.FetchTags;

namespace soa.ui.Store.Tags.Reducers.FetchTags
{
  public class FetchTagListReducerFailedActionReducer : Reducer<TagState, FetchTagListFailedAction>
  {
    public override TagState Reduce(TagState state, FetchTagListFailedAction action)
    {
      return new TagState(
        state.TagList,
        action.ErrorMessage,
        state.IsLoading,
        state.Tag,
        state.TagToBeCreatedPayload,
        state.TagToBeUpdatePayload,
        state.TagId
        );
    }
  }
}