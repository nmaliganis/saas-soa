namespace soa.ui.Store.Answers.Actions.FetchAnswer
{
  public class FetchAnswerFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchAnswerFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}