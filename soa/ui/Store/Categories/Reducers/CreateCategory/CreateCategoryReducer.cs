using Fluxor;
using soa.ui.Store.Categories.Actions.CreateCategory;

namespace soa.ui.Store.Categories.Reducers.CreateCategory
{
    public class CreateCategoryReducer : Reducer<CategoryState, CreateCategoryAction>
    {
        public override CategoryState Reduce(CategoryState state, CreateCategoryAction action)
        {
            return new CategoryState(
                state.CategoryList, 
                state.ErrorMessage, 
                state.IsLoading, 
                state.Category,
                action.CategoryToBeCreatedPayload,
                state.CategoryToBeUpdatePayload,
                0);
        }
    }
}