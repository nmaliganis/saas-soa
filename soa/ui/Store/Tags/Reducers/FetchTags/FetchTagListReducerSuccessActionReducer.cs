using Fluxor;
using soa.ui.Store.Tags.Actions.FetchTags;

namespace soa.ui.Store.Tags.Reducers.FetchTags
{
  public class FetchTagListReducerSuccessActionReducer : Reducer<TagState, FetchTagListSuccessAction>
  {
    public override TagState Reduce(TagState state, FetchTagListSuccessAction action)
    {
      return new TagState(
        action.TagList,
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