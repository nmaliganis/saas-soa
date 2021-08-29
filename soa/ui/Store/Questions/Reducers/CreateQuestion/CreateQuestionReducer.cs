using Fluxor;
using soa.ui.Store.Questions;
using soa.ui.Store.Questions.Actions.CreateQuestion;

namespace supermarket.fe.Store.Questions.Reducers.CreateQuestion
{
    public class CreateQuestionReducer : Reducer<QuestionState, CreateQuestionAction>
    {
        public override QuestionState Reduce(QuestionState state, CreateQuestionAction action)
        {
            return new QuestionState(
                state.QuestionList, 
                state.QuestionTodayList, 
                state.QuestionUnansweredList, 
                "", 
                state.IsLoading, 
                state.Question, 
                action.QuestionToBeCreatedPayload, 
                state.QuestionToBeUpdatePayload, 
                state.QuestionId
                );
        }
    }
}