using Fluxor;
using soa.ui.Store.Questions.Actions.FetchQuestions;

namespace soa.ui.Store.Questions.Reducers.FetchQuestions
{
  public class FetchQuestionListReducerFailedActionReducer : Reducer<QuestionState, FetchQuestionListFailedAction>
  {
    public override QuestionState Reduce(QuestionState state, FetchQuestionListFailedAction action)
    {
      return new QuestionState(
        state.QuestionList,
        state.QuestionTodayList,
        state.QuestionUnansweredList,
        action.ErrorMessage,
        state.IsLoading,
        state.Question,
        state.QuestionToBeCreatedPayload,
        state.QuestionToBeUpdatePayload,
        state.QuestionId
        );
    }
  }
}