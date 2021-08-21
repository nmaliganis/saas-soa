namespace soa.ui.Store.Questions.Actions.FetchQuestion
{
  public class FetchQuestionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchQuestionFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}