using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Base;
using soa.ui.Services.Contracts.Tags;
using soa.ui.Store.Tags.Actions.CreateTag;

namespace soa.ui.Store.Tags.Effects.CreateTag
{
    public class CreateTagEffect : Effect<CreateTagAction>
    {
        public ITagDataService TagDataService { get; set; }

        public CreateTagEffect(ITagDataService tagDataService)
        {
            TagDataService = tagDataService;
        }

        public override async Task HandleAsync(CreateTagAction action, IDispatcher dispatcher)
        {
            try
            {
                var createdTag = await TagDataService.CreateTag(action.TagToBeCreatedPayload);
                if (createdTag.Id != 0)
                {
                    dispatcher.Dispatch(new CreateTagSuccessAction(createdTag));
                }

            }
            catch (ServiceHttpRequestException<string> e)
            {
                dispatcher.Dispatch(new CreateTagFailedAction(errorMessage: e.Message, e.Content));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new CreateTagFailedAction(errorMessage: e.Message, e.InnerException?.Message));
            }
        }
    }
}