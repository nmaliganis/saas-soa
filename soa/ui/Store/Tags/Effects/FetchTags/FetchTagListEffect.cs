using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Tags;
using soa.ui.Store.Tags.Actions.FetchTags;

namespace soa.ui.Store.Tags.Effects.FetchTags
{
  public class FetchTagListEffect : Effect<FetchTagListAction>
  {
    public ITagDataService TagDataService { get; set; }
    public FetchTagListEffect(ITagDataService tagDataService)
    {
      TagDataService = tagDataService;
    }

    public override async Task HandleAsync(FetchTagListAction action, IDispatcher dispatcher)
    {
      try
      {
        var Tags = await TagDataService.GetTagList(action.Auth);
        dispatcher.Dispatch(new FetchTagListSuccessAction(Tags));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchTagListFailedAction(e.Message));
      }      
    }
  }
}