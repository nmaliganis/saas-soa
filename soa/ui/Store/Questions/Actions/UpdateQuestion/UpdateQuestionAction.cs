using System;

namespace soa.ui.Store.Questions.Actions.UpdateQuestion
{
  public class UpdateQuestionAction
  {
    public Guid QuestionToBeUpdateId { get; private set; }

    public UpdateQuestionAction(Guid questionToBeUpdateId)
    {
      QuestionToBeUpdateId = questionToBeUpdateId;
    }
  }
}