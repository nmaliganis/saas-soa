using System;

namespace soa.common.infrastructure.Exceptions.Domain.Answers
{
  public class InvalidAnswerException : Exception
  {
    public string BrokenRules { get; private set; }

    public InvalidAnswerException(string brokenRules)
    {
      BrokenRules = brokenRules;
    }
  }
}