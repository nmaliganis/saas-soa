namespace soa.ui.Store.Answers.Actions.FetchAnswers
{
  public class FetchAnswerListAction
  {
    public string Auth { get; }

    public FetchAnswerListAction(string auth)
    {
      Auth = auth;
    }
  }
}