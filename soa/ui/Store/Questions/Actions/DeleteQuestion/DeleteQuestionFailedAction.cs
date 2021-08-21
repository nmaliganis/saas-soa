namespace soa.ui.Store.Questions.Actions.DeleteQuestion
{
  public class DeleteQuestionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteQuestionFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}