using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions.Actions.CreateQuestion
{
  public class CreateQuestionSuccessAction
  {
    public QuestionDto QuestionHaveBeenCreated { get; private set; }

    public CreateQuestionSuccessAction(QuestionDto questionHaveBeenCreated)
    {
      QuestionHaveBeenCreated = questionHaveBeenCreated;
    }
  }
}