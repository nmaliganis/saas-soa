using System;

namespace soa.ui.Store.Questions.Actions.UpdateQuestion
{
  public class UpdateQuestionSuccessAction
  {
    public Guid QuestionHaveBeenUpdateId { get; private set; }
    public string QuestionDeletionStatus { get; private set; }

    public UpdateQuestionSuccessAction(Guid questionHaveBeenUpdateId, string questionDeletionStatus)
    {
      QuestionHaveBeenUpdateId = questionHaveBeenUpdateId;
      QuestionDeletionStatus = questionDeletionStatus;
    }
  }
}