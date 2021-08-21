namespace soa.ui.Store.Questions.Actions.FetchQuestions
{
  public class FetchQuestionListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchQuestionListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}