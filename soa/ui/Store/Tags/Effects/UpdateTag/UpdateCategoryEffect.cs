using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Tags;
using soa.ui.Store.Tags.Actions.UpdateTag;

namespace soa.ui.Store.Tags.Effects.UpdateTag
{
    public class UpdateTagEffect : Effect<UpdateTagAction>
    {
        public ITagDataService TagDataService { get; set; }
        public UpdateTagEffect(ITagDataService tagDataService)
        {
            TagDataService = tagDataService;
        }

        public override async Task HandleAsync(UpdateTagAction action, IDispatcher dispatcher)
        {
            try
            {
                var updatedTag = await TagDataService.UpdateTag(action.TagToBeUpdateId, action.TagForModificationDto);
                dispatcher.Dispatch(new UpdateTagSuccessAction(updatedTag.Id, updatedTag));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new UpdateTagFailedAction(errorMessage: e.Message));
            }
        }
    }
}