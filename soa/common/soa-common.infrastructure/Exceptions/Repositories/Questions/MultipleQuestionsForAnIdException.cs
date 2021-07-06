using System;

namespace soa.common.infrastructure.Exceptions.Repositories.Questions
{
  public class MultipleQuestionsForAnIdException : Exception
  {
    private readonly Guid _questionId;

    public MultipleQuestionsForAnIdException(Guid id)
    {
      this._questionId = id;
    }

    public override string Message => $"Multiple Questions found for: {_questionId}";
  }
}
