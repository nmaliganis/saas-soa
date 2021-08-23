using Fluxor;
using soa.ui.Store.Categories.Actions.UpdateCategory;

namespace soa.ui.Store.Categories.Reducers.UpdateCategory
{
    public class UpdateCategoryReducerFailedActionReducer : Reducer<CategoryState, UpdateCategoryFailedAction>
    {
        public override CategoryState Reduce(CategoryState state, UpdateCategoryFailedAction action)
        {
            return new CategoryState(
                state.CategoryList,
                action.ErrorMessage, 
                false, 
                state.Category, 
                state.CategoryToBeCreatedPayload, 
                state.CategoryToBeUpdatePayload,
                state.CategoryId);
        }
    }
}