using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using soa.ui.Models.DTOs.Answers;
using soa.ui.Models.DTOs.Questions;
using soa.ui.Store.Answers;
using soa.ui.Store.Answers.Actions.FetchAnswers;
using soa.ui.Store.Questions;
using soa.ui.Store.Questions.Actions.FetchQuestions;
using Telerik.Blazor.Components;

namespace soa.ui.Pages.Questions
{
  public class QuestionsViewModel : FluxorComponent
  {
    [Inject] public IDispatcher Dispatcher { get; set; }
    [Inject] public IState<QuestionState> QuestionState { get; set; }
    [Inject] public IState<AnswerState> AnswerState { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IConfiguration Configuration { get; set; }

    #region Initialization

    protected override Task OnInitializedAsync()
    {
      Dispatcher.Dispatch(new FetchQuestionListAction(""));

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

    #region Functions

    protected void PageChangedHandler(int currentPage)
    {

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
    
    protected void PageAnswerChangedHandler(int currentPage)
    {

    }
    
    public AnswerDto SelectedAnswerItem { get; set; }
    private IEnumerable<AnswerDto> _selectedAnswersItems; 
    public IEnumerable<AnswerDto> SelectedAnswerItems 
    {
      get
      {
        if (_selectedAnswersItems != null && !Equals(_selectedAnswersItems, Enumerable.Empty<AnswerDto>()))
          return _selectedAnswersItems;

        if(AnswerState.Value.AnswerList == null)
          return _selectedAnswersItems = Enumerable.Empty<AnswerDto>();
        SelectedAnswerItem = AnswerState.Value.AnswerList.FirstOrDefault();
        return _selectedAnswersItems = new List<AnswerDto> { SelectedAnswerItem };
      }
      set => _selectedAnswersItems = value;
    }

    protected string AnswerToBeAskedBody = String.Empty;
    
    protected void OnAnswerSelect(IEnumerable<AnswerDto> answerItems)
    {
      SelectedAnswerItem = answerItems.FirstOrDefault();
      SelectedAnswerItems = new List<AnswerDto> { SelectedAnswerItem };

      AnswerToBeAskedBody = SelectedAnswerItem.Body;
    }

    #endregion

    #region Commands

    protected void AddCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"Question-details/{Guid.Empty}");
      StateHasChanged();
    }
    protected void EditCommandFromToolbar(GridCommandEventArgs args)
    {
      NavigationManager.NavigateTo($"Question-details/{SelectedQuestionItems?.FirstOrDefault()?.Id}");
      StateHasChanged();
    }

    protected void DeleteCommandFromToolbar(GridCommandEventArgs args)
    {
      StateHasChanged();
    }

    #endregion

    #region Buttons

    [Parameter] public bool SaveBtnEnabled { get; set; } = true;

    protected async Task OnAddQuestionClickHandler()
    {
      NavigationManager.NavigateTo($"askquestion");
      StateHasChanged();
    }
    
    protected async Task OnAddAnAnswerClickHandler()
    {
      NavigationManager.NavigateTo($"giveanswer");
      StateHasChanged();
    }

    #endregion
  }
}