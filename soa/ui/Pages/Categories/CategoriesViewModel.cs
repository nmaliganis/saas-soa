using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using smart.charger.webui.Models.DTOs.Vehicles;
using smart.charger.webui.Store.Auth;
using soa.ui.Models.DTOs.Categories;
using soa.ui.Store.Categories;
using soa.ui.Store.Categories.Actions.CreateCategory;
using soa.ui.Store.Categories.Actions.DeleteCategory;
using soa.ui.Store.Categories.Actions.FetchCategories;
using soa.ui.Store.Categories.Actions.UpdateCategory;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace soa.ui.Pages.Categories
{
    public class CategoriesViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<CategoryState> CategoryState { get; set; }
        [Inject] public IState<AuthState> AuthState { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

        #region List Vehicle

        public DateTime? StartValue { get; set; } = DateTime.Now;
        public DateTime? EndValue { get; set; } = DateTime.Now.AddDays(10);

        protected VehicleDto BindVehicle { get; set; }

        public async Task OnChangeHandler(DateRangePickerChangeEventArgs e)
        {
            Console.WriteLine($"The range is from {e.StartValue} to {e.EndValue}");
        }

        public void VehicleOnChangeHandler(object theUserInput)
        {

        }

        #endregion

        #region Dates

        public DateTime FromDateInputValue { get; set; } = DateTime.Now;

        public TelerikDateInput<DateTime> From;

        public DateTime ToDateInputValue { get; set; } = DateTime.Now;

        public TelerikDateInput<DateTime> To;

        #endregion

        protected void NavigateToSignin()
        {
            //NavigationManager.NavigateTo($"signin");
        }

        #region Initialization

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new FetchCategoryListAction(AuthState.Value.JwtToken));
            StateHasChanged();
            return base.OnInitializedAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Functions

        protected void PageChangedHandler(int currentPage)
        {

        }

        public CategoryDto SelectedCategoryItem { get; set; }
        private IEnumerable<CategoryDto> _selectedItems;
        public IEnumerable<CategoryDto> SelectedCategoryItems
        {
            get
            {
                if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<CategoryDto>()))
                    return _selectedItems;

                if (CategoryState.Value.CategoryList == null)
                    return _selectedItems = Enumerable.Empty<CategoryDto>();
                SelectedCategoryItem = CategoryState.Value.CategoryList.FirstOrDefault();
                return _selectedItems = new List<CategoryDto> { SelectedCategoryItem };
            }
            set => _selectedItems = value;
        }

        protected void OnCategorySelect(IEnumerable<CategoryDto> categoryItems)
        {
            SelectedCategoryItem = categoryItems.FirstOrDefault();
            SelectedCategoryItems = new List<CategoryDto> { SelectedCategoryItem };
        }

        #endregion


        #region Buttons

        [Parameter] public bool SaveBtnEnabled { get; set; } = true;

        protected async Task OnAddCategoryClickHandler(GridCommandEventArgs args)
        {
            var addCategory = (CategoryDto)args.Item;

            if (addCategory.Id == 0)
            {
                Dispatcher.Dispatch(new CreateCategoryAction(new CategoryForCreationDto()
                {
                    Name = addCategory.Name,
                }));
            }

            StateHasChanged();
        }

        protected async Task OnEditCategoryClickHandler(GridCommandEventArgs args)
        {
            var editCategory = (CategoryDto)args.Item;

            if (editCategory.Id != 0)
            {
                Dispatcher.Dispatch(new UpdateCategoryAction( editCategory.Id, new CategoryForModificationDto()
                {
                    Id = editCategory.Id,
                    Name = editCategory.Name,
                }));
            }
            StateHasChanged();
        }

        protected async Task OnDeleteCategoryClickHandler(GridCommandEventArgs args)
        {
            var deleteCategory = (CategoryDto)args.Item;

            if (deleteCategory.Id != 0)
            {
                Dispatcher.Dispatch(new DeleteCategoryAction(deleteCategory.Id));
            }
            StateHasChanged();
        }

        #endregion


        #region Grid

        public TelerikGrid<CategoryDto> CategoriesGrid { get; set; }

        public void OnStateInit(GridStateEventArgs<CategoryDto> args)
        {
            args.GridState.GroupDescriptors = new List<GroupDescriptor>()
            {
                new GroupDescriptor()
                {
                    Member = nameof(CategoryDto.Name),
                    MemberType = typeof(string)
                }
            };
        }

        #endregion
    }
}
