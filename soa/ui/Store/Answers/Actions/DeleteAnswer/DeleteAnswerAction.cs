using System;

namespace soa.ui.Store.Answers.Actions.DeleteAnswer
{
  public class DeleteAnswerAction
  {
    public Guid AnswerToBeDeletedId { get; private set; }

    public DeleteAnswerAction(Guid answerToBeDeletedId)
    {
      AnswerToBeDeletedId = answerToBeDeletedId;
    }
  }
}