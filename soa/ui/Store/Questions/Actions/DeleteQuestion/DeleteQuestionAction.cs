using System;

namespace soa.ui.Store.Questions.Actions.DeleteQuestion
{
  public class DeleteQuestionAction
  {
    public Guid QuestionToBeDeletedId { get; private set; }

    public DeleteQuestionAction(Guid questionToBeDeletedId)
    {
      QuestionToBeDeletedId = questionToBeDeletedId;
    }
  }
}