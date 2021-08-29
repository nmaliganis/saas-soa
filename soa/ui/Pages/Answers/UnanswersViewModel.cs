using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using soa.ui.Models.DTOs.Questions;
using soa.ui.Store.Answers;
using soa.ui.Store.Answers.Actions.FetchAnswers;
using soa.ui.Store.Questions;
using soa.ui.Store.Questions.Actions.FetchQuestions;

namespace soa.ui.Pages.Answers
{
  public class UnanswersViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<QuestionState> QuestionState { get; set; }
    [Inject] public IState<AnswerState> AnswerState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IConfiguration Configuration { get; set; }

    [Parameter] public bool SaveBtnEnabled { get; set; } = true;
    
    #region Initialization

    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchQuestionWithoutAnswersListAction());

      StateHasChanged();
      return base.OnInitializedAsync();
    }

    protected override void Dispose(bool disposing)
    {
      _selectedQryItems = null;
      base.Dispose(disposing);
      GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    #endregion

    protected void PageChangedHandler(int currentPage)
    {

    }

    protected async Task OnAddAnswerClickHandler()
    {
      NavigationManager.NavigateTo($"addanswer");
      StateHasChanged();
    }
    
    public QuestionDto SelectedQuestionItem { get; set; }
    private IEnumerable<QuestionDto> _selectedQryItems; 
    public IEnumerable<QuestionDto> SelectedQuestionItems 
    {
      get
      {
        if (_selectedQryItems != null && !Equals(_selectedQryItems, Enumerable.Empty<QuestionDto>()))
          return _selectedQryItems;

        if(QuestionState.Value.QuestionList == null)
          return _selectedQryItems = Enumerable.Empty<QuestionDto>();
        SelectedQuestionItem = QuestionState.Value.QuestionList.FirstOrDefault();
        return _selectedQryItems = new List<QuestionDto> { SelectedQuestionItem };
      }
      set => _selectedQryItems = value;
    }

    protected string QuestionToBeAskedBody = String.Empty;
    protected void OnSelect(IEnumerable<QuestionDto> QuestionItems)
    {
      SelectedQuestionItem = QuestionItems.FirstOrDefault();
      SelectedQuestionItems = new List<QuestionDto> { SelectedQuestionItem };

      QuestionToBeAskedBody = SelectedQuestionItem.Body;
      Dispatcher.Dispatch(new FetchAnswerListAction(SelectedQuestionItem.Id));
    }
  }
}