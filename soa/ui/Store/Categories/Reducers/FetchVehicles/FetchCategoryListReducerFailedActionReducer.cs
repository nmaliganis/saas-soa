using Fluxor;
using soa.ui.Store.Categories.Actions.FetchCategories;

namespace soa.ui.Store.Categories.Reducers.FetchVehicles
{
  public class FetchCategoryListReducerFailedActionReducer : Reducer<CategoryState, FetchCategoryListFailedAction>
  {
    public override CategoryState Reduce(CategoryState state, FetchCategoryListFailedAction action)
    {
      return new CategoryState(
        state.CategoryList,
        action.ErrorMessage,
        state.IsLoading,
        state.Category,
        state.CategoryToBeCreatedPayload,
        state.CategoryToBeUpdatePayload,
        state.CategoryId
        );
    }
  }
}