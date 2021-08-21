using Fluxor;
using soa.ui.Store.Answers.Actions.FetchAnswers;

namespace soa.ui.Store.Answers.Reducers.FetchAnswers
{
  public class FetchAnswerListReducerSuccessActionReducer : Reducer<AnswerState, FetchAnswerListSuccessAction>
  {
    public override AnswerState Reduce(AnswerState state, FetchAnswerListSuccessAction action)
    {
      return new AnswerState(
        action.AnswerList,
        "",
        state.IsLoading,
        state.Answer,
        state.AnswerToBeCreatedPayload,
        state.AnswerToBeUpdatePayload,
        state.AnswerId
      );
    }
  }
}