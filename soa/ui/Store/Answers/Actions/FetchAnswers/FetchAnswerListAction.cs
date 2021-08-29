namespace soa.ui.Store.Answers.Actions.FetchAnswers
{
  public class FetchAnswerListAction
  {
    public int QuestionId { get; }

    public FetchAnswerListAction(int questionId)
    {
      QuestionId = questionId;
    }
  }
}