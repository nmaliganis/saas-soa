using System;

namespace soa.ui.Store.Questions.Actions.DeleteQuestion
{
  public class DeleteQuestionSuccessAction
  {
    public Guid QuestionHaveBeenDeletedId { get; private set; }
    public string QuestionDeletionStatus { get; private set; }

    public DeleteQuestionSuccessAction(Guid questionHaveBeenDeletedId, string questionDeletionStatus)
    {
      QuestionHaveBeenDeletedId = questionHaveBeenDeletedId;
      QuestionDeletionStatus = questionDeletionStatus;
    }
  }
}