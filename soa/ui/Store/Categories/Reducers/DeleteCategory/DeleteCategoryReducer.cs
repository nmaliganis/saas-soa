using Fluxor;
using soa.ui.Store.Categories.Actions.DeleteCategory;

namespace soa.ui.Store.Categories.Reducers.DeleteCategory
{
    public class DeleteCategoryReducer : Reducer<CategoryState, DeleteCategoryAction>
    {
        public override CategoryState Reduce(CategoryState state, DeleteCategoryAction action)
        {
            return new CategoryState(
                state.CategoryList, 
                state.ErrorMessage, 
                state.IsLoading, 
                state.Category,
                state.CategoryToBeCreatedPayload,
                state.CategoryToBeUpdatePayload,
                action.CategoryToBeDeletedId);
        }
    }
}