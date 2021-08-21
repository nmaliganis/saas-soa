using System;

namespace soa.ui.Store.Questions.Actions.FetchQuestion
{
  public class FetchQuestionAction
  {
    public Guid QuestionToBeFetchedId { get; private set; }

    public FetchQuestionAction(Guid questionToBeFetchedId)
    {
      QuestionToBeFetchedId = questionToBeFetchedId;
    }
  }
}