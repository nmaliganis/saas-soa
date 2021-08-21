using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions.Actions.FetchQuestion
{
  public class FetchQuestionSuccessAction
  {
    public QuestionDto QuestionToHaveBeenFetched { get; private set; }

    public FetchQuestionSuccessAction(QuestionDto questionToHaveBeenFetched)
    {
      QuestionToHaveBeenFetched  = questionToHaveBeenFetched;
    }
  }
}