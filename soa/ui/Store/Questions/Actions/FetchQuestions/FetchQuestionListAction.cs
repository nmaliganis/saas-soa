namespace soa.ui.Store.Questions.Actions.FetchQuestions
{
  public class FetchQuestionListAction
  {
    public string Auth { get; }

    public FetchQuestionListAction(string auth)
    {
      Auth = auth;
    }
  }
}