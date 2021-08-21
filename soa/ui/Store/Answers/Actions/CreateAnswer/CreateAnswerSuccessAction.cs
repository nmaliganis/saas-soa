using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Store.Answers.Actions.CreateAnswer
{
  public class CreateAnswerSuccessAction
  {
    public AnswerDto AnswerHaveBeenCreated { get; private set; }

    public CreateAnswerSuccessAction(AnswerDto answerHaveBeenCreated)
    {
      AnswerHaveBeenCreated = answerHaveBeenCreated;
    }
  }
}