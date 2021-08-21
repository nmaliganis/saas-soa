using System.Collections.Generic;
using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Store.Answers.Actions.FetchAnswers
{
  public class FetchAnswerListSuccessAction
  {
    public List<AnswerDto> AnswerList { get; private set; }

    public FetchAnswerListSuccessAction(List<AnswerDto> answerList)
    {
      AnswerList  = answerList;
    }
  }
}