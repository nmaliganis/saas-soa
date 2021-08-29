using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Base;
using soa.ui.Services.Contracts.Questions;
using soa.ui.Store.Questions.Actions.CreateQuestion;

namespace supermarket.fe.Store.Questions.Effects.CreateQuestion
{
    public class CreateQuestionEffect : Effect<CreateQuestionAction>
    {
        public IQuestionDataService QuestionDataService { get; set; }
        public CreateQuestionEffect(IQuestionDataService questionDataService)
        {
            QuestionDataService = questionDataService;
        }
        
        public override async Task HandleAsync(CreateQuestionAction action, IDispatcher dispatcher)
        {
            try
            {
                var createdQuestion = await QuestionDataService.CreateQuestion(action.QuestionToBeCreatedPayload);
                dispatcher.Dispatch(new CreateQuestionSuccessAction(createdQuestion));
            }
            catch (ServiceHttpRequestException<string> e)
            {
                dispatcher.Dispatch(new CreateQuestionFailedAction(errorMessage: e.Message, e.Content));
            }     
            catch (Exception e)
            {
                dispatcher.Dispatch(new CreateQuestionFailedAction(errorMessage: e.Message, e.InnerException?.Message));
            }  
        }
    }
}