using System;
using Fluxor;
using soa.ui.Store.Categories.Actions.CreateCategory;

namespace soa.ui.Store.Categories.Reducers.CreateCategory
{
    public class CreateCategoryReducerSuccessActionReducer : Reducer<CategoryState, CreateCategorySuccessAction>
    {
        public override CategoryState Reduce(CategoryState state, CreateCategorySuccessAction action)
        {
            var categoryList =  state.CategoryList;

            categoryList.Add(action.CategoryHaveBeenCreated);

            return new CategoryState(
                categoryList, 
                action.CategoryHaveBeenCreated.Message, 
                true, 
                action.CategoryHaveBeenCreated,
                state.CategoryToBeCreatedPayload,
                state.CategoryToBeUpdatePayload,
                state.CategoryId
                );
        }
    }
}