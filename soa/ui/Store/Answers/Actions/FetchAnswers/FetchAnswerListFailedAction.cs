namespace soa.ui.Store.Answers.Actions.FetchAnswers
{
  public class FetchAnswerListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchAnswerListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}