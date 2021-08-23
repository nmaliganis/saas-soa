using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Categories;
using soa.ui.Store.Categories.Actions.FetchCategories;

namespace soa.ui.Store.Categories.Effects.FetchCategories
{
  public class FetchCategoryListEffect : Effect<FetchCategoryListAction>
  {
    public ICategoryDataService CategoryDataService { get; set; }
    public FetchCategoryListEffect(ICategoryDataService categoryDataService)
    {
      CategoryDataService = categoryDataService;
    }

    public override async Task HandleAsync(FetchCategoryListAction action, IDispatcher dispatcher)
    {
      try
      {
        var categories = await CategoryDataService.GetCategoryList(action.Auth);
        dispatcher.Dispatch(new FetchCategoryListSuccessAction(categories));
      }
      catch (Exception e)
      {
        dispatcher.Dispatch(new FetchCategoryListFailedAction(e.Message));
      }      
    }
  }
}