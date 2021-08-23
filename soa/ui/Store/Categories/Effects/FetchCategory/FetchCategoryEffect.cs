using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Categories;
using soa.ui.Store.Categories.Actions.FetchCategory;

namespace soa.ui.Store.Categories.Effects.FetchCategory
{
    public class FetchCategoryEffect : Effect<FetchCategoryAction>
    {
        public ICategoryDataService CategoryDataService { get; set; }
        public FetchCategoryEffect(ICategoryDataService categoryDataService)
        {
            CategoryDataService = categoryDataService;
        }

        public override async Task HandleAsync(FetchCategoryAction action, IDispatcher dispatcher)
        {
            try
            {
                var category = await CategoryDataService.GetCategory(action.CategoryToBeFetchedId);
                dispatcher.Dispatch(new FetchCategorySuccessAction(category));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new FetchCategoryFailedAction(errorMessage: e.Message));
            }
        }
    }
}