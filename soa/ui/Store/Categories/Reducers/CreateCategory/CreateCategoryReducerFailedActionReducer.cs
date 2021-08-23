using Fluxor;
using soa.ui.Store.Categories.Actions.CreateCategory;

namespace soa.ui.Store.Categories.Reducers.CreateCategory
{
    public class CreateCategoryReducerFailedActionReducer : Reducer<CategoryState, CreateCategoryFailedAction>
    {
        public override CategoryState Reduce(CategoryState state, CreateCategoryFailedAction action)
        {
            return new CategoryState(
                state.CategoryList,
                action.ErrorContent, 
                false, 
                state.Category, 
                state.CategoryToBeCreatedPayload, 
                state.CategoryToBeUpdatePayload,
                state.CategoryId);
        }
    }
}