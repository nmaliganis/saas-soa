namespace soa.ui.Store.Answers.Actions.UpdateAnswer
{
  public class UpdateAnswerFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateAnswerFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}