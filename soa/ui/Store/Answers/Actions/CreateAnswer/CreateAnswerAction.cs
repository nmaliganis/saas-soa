using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Store.Answers.Actions.CreateAnswer
{
  public class CreateAnswerAction
  {
    public CreateAnswerAction(AnswerForCreationDto answerToBeCreatedPayload)
    {
      AnswerToBeCreatedPayload = answerToBeCreatedPayload;
    }

    public AnswerForCreationDto AnswerToBeCreatedPayload { get; private set; }
  }
}