using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Categories;
using soa.ui.Store.Categories.Actions.UpdateCategory;

namespace soa.ui.Store.Categories.Effects.UpdateCategory
{
    public class UpdateCategoryEffect : Effect<UpdateCategoryAction>
    {
        public ICategoryDataService CategoryDataService { get; set; }
        public UpdateCategoryEffect(ICategoryDataService categoryDataService)
        {
            CategoryDataService = categoryDataService;
        }

        public override async Task HandleAsync(UpdateCategoryAction action, IDispatcher dispatcher)
        {
            try
            {
                var updatedCategory = await CategoryDataService.UpdateCategory(action.CategoryToBeUpdateId, action.CategoryForModification);
                dispatcher.Dispatch(new UpdateCategorySuccessAction(updatedCategory.Id, updatedCategory));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new UpdateCategoryFailedAction(errorMessage: e.Message));
            }
        }
    }
}