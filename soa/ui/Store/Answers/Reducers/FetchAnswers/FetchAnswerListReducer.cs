using Fluxor;
using soa.ui.Store.Answers.Actions.FetchAnswers;

namespace soa.ui.Store.Answers.Reducers.FetchAnswers
{
  public class FetchAnswerListReducer : Reducer<AnswerState, FetchAnswerListAction>
  {
    public override AnswerState Reduce(AnswerState state, FetchAnswerListAction action)
    {
      return new AnswerState(
        state.AnswerList,
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