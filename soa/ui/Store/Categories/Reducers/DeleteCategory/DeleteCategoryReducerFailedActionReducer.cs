using Fluxor;
using soa.ui.Store.Categories.Actions.DeleteCategory;

namespace soa.ui.Store.Categories.Reducers.DeleteCategory
{
    public class DeleteCategoryReducerFailedActionReducer : Reducer<CategoryState, DeleteCategoryFailedAction>
    {
        public override CategoryState Reduce(CategoryState state, DeleteCategoryFailedAction action)
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