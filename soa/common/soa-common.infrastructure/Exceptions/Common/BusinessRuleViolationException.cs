using System;

namespace soa.common.infrastructure.Exceptions.Common
{
    public class BusinessRuleViolationException : Exception
    {
        public BusinessRuleViolationException(string incorrectTaskStatus) : base(incorrectTaskStatus)
        {
        }
    }
}