﻿using System;

namespace soa.common.infrastructure.Exceptions.Domain.Categories
{
  public class InvalidCategoryException : Exception
  {
    public string BrokenRules { get; private set; }

    public InvalidCategoryException(string brokenRules)
    {
      BrokenRules = brokenRules;
    }
  }
}