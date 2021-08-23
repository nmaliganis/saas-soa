using Fluxor;
using soa.ui.Store.Categories.Actions.FetchCategories;

namespace soa.ui.Store.Categories.Reducers.FetchCategories
{
  public class FetchCategoryListReducer : Reducer<CategoryState, FetchCategoryListAction>
  {
    public override CategoryState Reduce(CategoryState state, FetchCategoryListAction action)
    {
      return new CategoryState(
        state.CategoryList,
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