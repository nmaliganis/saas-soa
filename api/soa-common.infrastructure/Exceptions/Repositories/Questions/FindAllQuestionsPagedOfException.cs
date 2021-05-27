using System;

namespace soa.common.infrastructure.Exceptions.Repositories.Questions
{
  public class FindAllQuestionsPagedOfException : Exception
  {
    private readonly string _messageDetails;

    public FindAllQuestionsPagedOfException(string messageDetails)
    {
      this._messageDetails = messageDetails;
    }

    public override string Message => $"Find all Questions error: {_messageDetails}";
  }
}
