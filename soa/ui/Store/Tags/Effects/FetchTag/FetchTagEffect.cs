using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Tags;
using soa.ui.Store.Tags.Actions.FetchTag;

namespace soa.ui.Store.Tags.Effects.FetchTag
{
    public class FetchTagEffect : Effect<FetchTagAction>
    {
        public ITagDataService TagDataService { get; set; }
        public FetchTagEffect(ITagDataService tagDataService)
        {
            TagDataService = tagDataService;
        }

        public override async Task HandleAsync(FetchTagAction action, IDispatcher dispatcher)
        {
            try
            {
                var Tag = await TagDataService.GetTag(action.TagToBeFetchedId);
                dispatcher.Dispatch(new FetchTagSuccessAction(Tag));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new FetchTagFailedAction(errorMessage: e.Message));
            }
        }
    }
}