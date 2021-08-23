using Fluxor;
using soa.ui.Store.Categories.Actions.DeleteCategory;

namespace soa.ui.Store.Categories.Reducers.DeleteCategory
{
    public class DeleteCategoryReducerSuccessActionReducer : Reducer<CategoryState, DeleteCategorySuccessAction>
    {
        public override CategoryState Reduce(CategoryState state, DeleteCategorySuccessAction action)
        {
            return new CategoryState(
                state.CategoryList, 
                action.CategoryDeletionStatus, 
                true, 
                state.Category,
                state.CategoryToBeCreatedPayload,
                state.CategoryToBeUpdatePayload,
                action.CategoryHaveBeenDeletedId
                );
        }
    }
}