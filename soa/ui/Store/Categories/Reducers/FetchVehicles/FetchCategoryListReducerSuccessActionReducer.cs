using Fluxor;
using soa.ui.Store.Categories.Actions.FetchCategories;

namespace soa.ui.Store.Categories.Reducers.FetchVehicles
{
  public class FetchCategoryListReducerSuccessActionReducer : Reducer<CategoryState, FetchCategoryListSuccessAction>
  {
    public override CategoryState Reduce(CategoryState state, FetchCategoryListSuccessAction action)
    {
      return new CategoryState(
        action.CategoryList,
        "",
        state.IsLoading,
        state.Category,
        state.CategoryToBeCreatedPayload,
        state.CategoryToBeUpdatePayload,
        state.CategoryId
      );
    }
  }
}