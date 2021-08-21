using System.Collections.Generic;
using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions.Actions.FetchQuestions
{
  public class FetchQuestionListSuccessAction
  {
    public List<QuestionDto> QuestionList { get; private set; }

    public FetchQuestionListSuccessAction(List<QuestionDto> questionList)
    {
      QuestionList  = questionList;
    }
  }
}