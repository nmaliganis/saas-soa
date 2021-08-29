using Fluxor;
using soa.ui.Store.Questions;
using soa.ui.Store.Questions.Actions.CreateQuestion;

namespace supermarket.fe.Store.Questions.Reducers.CreateQuestion
{
    public class CreateQuestionReducerSuccessActionReducer : Reducer<QuestionState, CreateQuestionSuccessAction>
    {
        public override QuestionState Reduce(QuestionState state, CreateQuestionSuccessAction action)
        {
            return new QuestionState(
                state.QuestionList, 
                state.QuestionTodayList, 
                state.QuestionUnansweredList, 
                state.ErrorMessage, 
                state.IsLoading, 
                action.QuestionHaveBeenCreated, 
                state.QuestionToBeCreatedPayload, 
                state.QuestionToBeUpdatePayload, 
                state.QuestionId
            );
        }
    }
}