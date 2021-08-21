namespace soa.ui.Store.Answers.Actions.DeleteAnswer
{
  public class DeleteAnswerFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteAnswerFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}