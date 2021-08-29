using Fluxor;
using soa.ui.Store.Questions.Actions.FetchQuestions;

namespace soa.ui.Store.Questions.Reducers.FetchQuestions
{
  public class FetchQuestionListReducerSuccessActionReducer : Reducer<QuestionState, FetchQuestionListSuccessAction>
  {
    public override QuestionState Reduce(QuestionState state, FetchQuestionListSuccessAction action)
    {
      return new QuestionState(
        action.QuestionList,
        action.QuestionTodayList,
        action.QuestionUnansweredList,
        "",
        state.IsLoading,
        state.Question,
        state.QuestionToBeCreatedPayload,
        state.QuestionToBeUpdatePayload,
        state.QuestionId
      );
    }
  }
}