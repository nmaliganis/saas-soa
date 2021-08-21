using System;

namespace soa.ui.Store.Answers.Actions.UpdateAnswer
{
  public class UpdateAnswerAction
  {
    public Guid AnswerToBeUpdateId { get; private set; }

    public UpdateAnswerAction(Guid answerToBeUpdateId)
    {
      AnswerToBeUpdateId = answerToBeUpdateId;
    }
  }
}