﻿using System;

namespace ms.common.infrastructure.Exceptions.Domain.Persons
{
  public class InvalidPersonException : Exception
  {
    public string BrokenRules { get; private set; }

    public InvalidPersonException(string brokenRules)
    {
      BrokenRules = brokenRules;
    }
  }
}