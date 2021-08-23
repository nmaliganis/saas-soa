using System;
using Fluxor;
using soa.ui.Store.Categories.Actions.UpdateCategory;

namespace soa.ui.Store.Categories.Reducers.UpdateCategory
{
    public class UpdateCategoryReducerSuccessActionReducer : Reducer<CategoryState, UpdateCategorySuccessAction>
    {
        public override CategoryState Reduce(CategoryState state, UpdateCategorySuccessAction action)
        {
            var index = state.CategoryList.FindIndex(c => c.Id == action.CategoryHaveBeenUpdateId);
            state.CategoryList[index] = action.CategoryModification;

            var categoryList = state.CategoryList;

            return new CategoryState(
                categoryList, 
                state.ErrorMessage, 
                true, 
                state.Category,
                state.CategoryToBeCreatedPayload,
                state.CategoryToBeUpdatePayload,
                action.CategoryHaveBeenUpdateId
                );
        }
    }
}