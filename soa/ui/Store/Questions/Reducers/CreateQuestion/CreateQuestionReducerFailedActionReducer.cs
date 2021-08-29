using Fluxor;
using soa.ui.Store.Questions;
using soa.ui.Store.Questions.Actions.CreateQuestion;

namespace supermarket.fe.Store.Questions.Reducers.CreateQuestion
{
    public class CreateQuestionReducerFailedActionReducer : Reducer<QuestionState, CreateQuestionFailedAction>
    {
        public override QuestionState Reduce(QuestionState state, CreateQuestionFailedAction action)
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