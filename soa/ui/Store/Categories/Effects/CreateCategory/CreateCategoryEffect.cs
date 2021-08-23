using System;
using System.Threading.Tasks;
using Fluxor;
using smart.charger.webui.Services.Base;
using soa.ui.Services.Contracts.Categories;
using soa.ui.Store.Categories.Actions.CreateCategory;

namespace soa.ui.Store.Categories.Effects.CreateCategory
{
    public class CreateCategoryEffect : Effect<CreateCategoryAction>
    {
        public ICategoryDataService CategoryDataService { get; set; }

        public CreateCategoryEffect(ICategoryDataService categoryDataService)
        {
            CategoryDataService = categoryDataService;
        }

        public override async Task HandleAsync(CreateCategoryAction action, IDispatcher dispatcher)
        {
            try
            {
                var createdCategory = await CategoryDataService.CreateCategory(action.CategoryToBeCreatedPayload);
                if (createdCategory.Id != 0)
                {
                    dispatcher.Dispatch(new CreateCategorySuccessAction(createdCategory));
                }

            }
            catch (ServiceHttpRequestException<string> e)
            {
                dispatcher.Dispatch(new CreateCategoryFailedAction(errorMessage: e.Message, e.Content));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new CreateCategoryFailedAction(errorMessage: e.Message, e.InnerException?.Message));
            }
        }
    }
}