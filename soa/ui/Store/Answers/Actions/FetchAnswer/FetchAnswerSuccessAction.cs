using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Store.Answers.Actions.FetchAnswer
{
  public class FetchAnswerSuccessAction
  {
    public AnswerDto AnswerToHaveBeenFetched { get; private set; }

    public FetchAnswerSuccessAction(AnswerDto answerToHaveBeenFetched)
    {
      AnswerToHaveBeenFetched  = answerToHaveBeenFetched;
    }
  }
}