using System;

namespace ms.common.infrastructure.Exceptions.Domain.Tags
{
  public class InvalidTagException : Exception
  {
    public string BrokenRules { get; private set; }

    public InvalidTagException(string brokenRules)
    {
      BrokenRules = brokenRules;
    }
  }
}