using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions.Actions.CreateQuestion
{
  public class CreateQuestionAction
  {
    public CreateQuestionAction(QuestionForCreationDto questionToBeCreatedPayload)
    {
      QuestionToBeCreatedPayload = questionToBeCreatedPayload;
    }

    public QuestionForCreationDto QuestionToBeCreatedPayload { get; private set; }
  }
}