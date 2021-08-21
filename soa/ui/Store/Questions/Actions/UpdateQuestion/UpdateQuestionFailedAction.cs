namespace soa.ui.Store.Questions.Actions.UpdateQuestion
{
  public class UpdateQuestionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateQuestionFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}