using System.Collections.Generic;
using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions.Actions.FetchQuestions
{
  public class FetchQuestionListSuccessAction
  {
    public List<QuestionDto> QuestionList { get; private set; }
    public List<QuestionDto> QuestionTodayList { get; private set; }
    public List<QuestionDto> QuestionUnansweredList { get; private set; }

    public FetchQuestionListSuccessAction(List<QuestionDto> questionList,
        List<QuestionDto> questionTodayList, List<QuestionDto> questionUnansweredList)
    {
        QuestionList  = questionList;
        QuestionTodayList = questionTodayList;
        QuestionUnansweredList = questionUnansweredList;
    }
  }
}