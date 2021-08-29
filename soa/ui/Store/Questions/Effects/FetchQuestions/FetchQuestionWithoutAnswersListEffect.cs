using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Questions;
using soa.ui.Store.Questions.Actions.FetchQuestions;

namespace soa.ui.Store.Questions.Effects.FetchQuestions
{
    public class FetchQuestionWithoutAnswersListEffect : Effect<FetchQuestionWithoutAnswersListAction>
    {
        public IQuestionDataService QuestionDataService { get; set; }

        public FetchQuestionWithoutAnswersListEffect(IQuestionDataService questionDataService)
        {
            QuestionDataService = questionDataService;
        }

        public override async Task HandleAsync(FetchQuestionWithoutAnswersListAction action, IDispatcher dispatcher)
        {
            try
            {
                var questions = await QuestionDataService.GetQuestionList("");
                var questionsToday = await QuestionDataService.GetQuestionTodayList("");
                var questionsUnanswered = await QuestionDataService.GetQuestionUnansweredList("");
                dispatcher.Dispatch(new FetchQuestionListSuccessAction(questions, questionsToday, questionsUnanswered));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new FetchQuestionListFailedAction(e.Message));
            }
        }
    }
}