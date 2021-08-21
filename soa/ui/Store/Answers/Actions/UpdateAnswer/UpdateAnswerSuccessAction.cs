using System;

namespace soa.ui.Store.Answers.Actions.UpdateAnswer
{
  public class UpdateAnswerSuccessAction
  {
    public Guid AnswerHaveBeenUpdateId { get; private set; }
    public string AnswerDeletionStatus { get; private set; }

    public UpdateAnswerSuccessAction(Guid answerHaveBeenUpdateId, string answerDeletionStatus)
    {
      AnswerHaveBeenUpdateId = answerHaveBeenUpdateId;
      AnswerDeletionStatus = answerDeletionStatus;
    }
  }
}