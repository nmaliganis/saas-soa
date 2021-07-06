using System;

namespace soa.common.infrastructure.Exceptions.Domain.Answers
{
    public class AnswerAlreadyExistsException : Exception
    {
        public string NumPlate { get; }
        public string BrokenRules { get; }

        public AnswerAlreadyExistsException(string numPlate)
        {
          NumPlate = numPlate;
        }

        public AnswerAlreadyExistsException(string numPlate, string brokenRules)
        {
            NumPlate = numPlate;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Answer with Num Plate:{NumPlate} already Exists!\n" +
                                          $" Additional info:{BrokenRules}";
    }
}
