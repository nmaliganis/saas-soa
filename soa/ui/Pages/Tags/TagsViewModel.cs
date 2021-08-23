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
using soa.ui.Models.DTOs.Tags;
using soa.ui.Store.Tags;
using soa.ui.Store.Tags.Actions.CreateTag;
using soa.ui.Store.Tags.Actions.DeleteTag;
using soa.ui.Store.Tags.Actions.FetchTags;
using soa.ui.Store.Tags.Actions.UpdateTag;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace soa.ui.Pages.Tags
{
    public class TagsViewModel : FluxorComponent
    {
        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public IState<TagState> TagState { get; set; }
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
            Dispatcher.Dispatch(new FetchTagListAction(AuthState.Value.JwtToken));
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

        public TagDto SelectedTagItem { get; set; }
        private IEnumerable<TagDto> _selectedItems;
        public IEnumerable<TagDto> SelectedTagItems
        {
            get
            {
                if (_selectedItems != null && !Equals(_selectedItems, Enumerable.Empty<TagDto>()))
                    return _selectedItems;

                if (TagState.Value.TagList == null)
                    return _selectedItems = Enumerable.Empty<TagDto>();
                SelectedTagItem = TagState.Value.TagList.FirstOrDefault();
                return _selectedItems = new List<TagDto> { SelectedTagItem };
            }
            set => _selectedItems = value;
        }

        protected void OnTagSelect(IEnumerable<TagDto> TagItems)
        {
            SelectedTagItem = TagItems.FirstOrDefault();
            SelectedTagItems = new List<TagDto> { SelectedTagItem };
        }

        #endregion


        #region Buttons

        [Parameter] public bool SaveBtnEnabled { get; set; } = true;

        protected async Task OnAddTagClickHandler(GridCommandEventArgs args)
        {
            var addTag = (TagDto)args.Item;

            if (addTag.Id == 0)
            {
                Dispatcher.Dispatch(new CreateTagAction(new TagForCreationDto()
                {
                    Title = addTag.Title,
                    Description = addTag.Description,
                }));
            }

            StateHasChanged();
        }

        protected async Task OnEditTagClickHandler(GridCommandEventArgs args)
        {
            var editTag = (TagDto)args.Item;

            if (editTag.Id != 0)
            {
                Dispatcher.Dispatch(new UpdateTagAction( editTag.Id, new TagForModificationDto()
                {
                    Id = editTag.Id,
                    Title = editTag.Title,
                    Description = editTag.Description
                }));
            }
            StateHasChanged();
        }

        protected async Task OnDeleteTagClickHandler(GridCommandEventArgs args)
        {
            var deleteTag = (TagDto)args.Item;

            if (deleteTag.Id != 0)
            {
                Dispatcher.Dispatch(new DeleteTagAction(deleteTag.Id));
            }
            StateHasChanged();
        }

        #endregion


        #region Grid

        public TelerikGrid<TagDto> TagsGrid { get; set; }

        public void OnStateInit(GridStateEventArgs<TagDto> args)
        {
            args.GridState.GroupDescriptors = new List<GroupDescriptor>()
            {
                new GroupDescriptor()
                {
                    Member = nameof(TagDto.Title),
                    MemberType = typeof(string)
                }
            };
        }

        #endregion
    }
}
