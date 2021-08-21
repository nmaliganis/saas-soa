namespace soa.ui.Store.Questions.Actions.CreateQuestion
{
  public class CreateQuestionFailedAction
  {
    public string ErrorMessage { get; private set; }
    public string ErrorContent { get; private set; }
    public CreateQuestionFailedAction(string errorMessage, string errorContent)
    {
      ErrorMessage = errorMessage;
      ErrorContent = errorContent;
    }
  }
}