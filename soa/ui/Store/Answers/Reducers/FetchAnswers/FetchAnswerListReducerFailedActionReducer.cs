using Fluxor;
using soa.ui.Store.Answers.Actions.FetchAnswers;

namespace soa.ui.Store.Answers.Reducers.FetchAnswers
{
  public class FetchAnswerListReducerFailedActionReducer : Reducer<AnswerState, FetchAnswerListFailedAction>
  {
    public override AnswerState Reduce(AnswerState state, FetchAnswerListFailedAction action)
    {
      return new AnswerState(
        state.AnswerList,
        action.ErrorMessage,
        state.IsLoading,
        state.Answer,
        state.AnswerToBeCreatedPayload,
        state.AnswerToBeUpdatePayload,
        state.AnswerId
        );
    }
  }
}