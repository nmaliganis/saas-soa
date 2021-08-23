using System;
using System.Threading.Tasks;
using Fluxor;
using soa.ui.Services.Contracts.Categories;
using soa.ui.Store.Categories.Actions.DeleteCategory;

namespace soa.ui.Store.Categories.Effects.DeleteCategory
{
    public class DeleteCategoryEffect : Effect<DeleteCategoryAction>
    {
        public ICategoryDataService CategoryDataService { get; set; }

        public DeleteCategoryEffect(ICategoryDataService categoryDataService)
        {
            CategoryDataService = categoryDataService;
        }

        public override async Task HandleAsync(DeleteCategoryAction action, IDispatcher dispatcher)
        {
            try
            {
                var deletedCategory = await CategoryDataService.DeleteCategory(action.CategoryToBeDeletedId);
                dispatcher.Dispatch(new DeleteCategorySuccessAction(deletedCategory.Id, deletedCategory.Message));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new DeleteCategoryFailedAction(errorMessage: e.Message));
            }
        }
    }
}