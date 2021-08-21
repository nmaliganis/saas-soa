using System;

namespace soa.ui.Store.Answers.Actions.FetchAnswer
{
  public class FetchAnswerAction
  {
    public Guid AnswerToBeFetchedId { get; private set; }

    public FetchAnswerAction(Guid answerToBeFetchedId)
    {
      AnswerToBeFetchedId = answerToBeFetchedId;
    }
  }
}