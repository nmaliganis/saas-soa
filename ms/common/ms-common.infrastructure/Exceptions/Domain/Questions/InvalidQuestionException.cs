using System;

namespace ms.common.infrastructure.Exceptions.Domain.Questions
{
  public class InvalidQuestionException : Exception
  {
    public string BrokenRules { get; private set; }

    public InvalidQuestionException(string brokenRules)
    {
      BrokenRules = brokenRules;
    }
  }
}