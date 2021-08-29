using Fluxor;
using soa.ui.Store.Questions.Actions.FetchQuestions;

namespace soa.ui.Store.Questions.Reducers.FetchQuestions
{
  public class FetchQuestionListReducer : Reducer<QuestionState, FetchQuestionListAction>
  {
    public override QuestionState Reduce(QuestionState state, FetchQuestionListAction action)
    {
      return new QuestionState(
        state.QuestionList,
        state.QuestionTodayList,
        state.QuestionUnansweredList,
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