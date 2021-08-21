using System;

namespace soa.ui.Store.Answers.Actions.DeleteAnswer
{
  public class DeleteAnswerSuccessAction
  {
    public Guid AnswerHaveBeenDeletedId { get; private set; }
    public string AnswerDeletionStatus { get; private set; }

    public DeleteAnswerSuccessAction(Guid answerHaveBeenDeletedId, string answerDeletionStatus)
    {
      AnswerHaveBeenDeletedId = answerHaveBeenDeletedId;
      AnswerDeletionStatus = answerDeletionStatus;
    }
  }
}