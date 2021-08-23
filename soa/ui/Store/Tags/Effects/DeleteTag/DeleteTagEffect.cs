using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Tags;
using soa.ui.Store.Tags.Actions.DeleteTag;

namespace soa.ui.Store.Tags.Effects.DeleteTag
{
    public class DeleteTagEffect : Effect<DeleteTagAction>
    {
        public ITagDataService TagDataService { get; set; }

        public DeleteTagEffect(ITagDataService tagDataService)
        {
            TagDataService = tagDataService;
        }

        public override async Task HandleAsync(DeleteTagAction action, IDispatcher dispatcher)
        {
            try
            {
                var deletedTag = await TagDataService.DeleteTag(action.TagToBeDeletedId);
                dispatcher.Dispatch(new DeleteTagSuccessAction(deletedTag.Id, deletedTag.Message));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new DeleteTagFailedAction(errorMessage: e.Message));
            }
        }
    }
}