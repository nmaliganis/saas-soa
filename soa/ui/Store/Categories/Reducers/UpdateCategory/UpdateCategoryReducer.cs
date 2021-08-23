using Fluxor;
using soa.ui.Store.Categories.Actions.UpdateCategory;

namespace soa.ui.Store.Categories.Reducers.UpdateCategory
{
    public class UpdateCategoryReducer : Reducer<CategoryState, UpdateCategoryAction>
    {
        public override CategoryState Reduce(CategoryState state, UpdateCategoryAction action)
        {
            return new CategoryState(
                state.CategoryList, 
                state.ErrorMessage, 
                state.IsLoading, 
                state.Category,
                state.CategoryToBeCreatedPayload,
                action.CategoryForModification,
                state.CategoryId
                );
        }
    }
}