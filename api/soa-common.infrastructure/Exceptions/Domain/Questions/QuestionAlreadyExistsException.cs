using System;

namespace soa.common.infrastructure.Exceptions.Domain.Questions
{
    public class QuestionAlreadyExistsException : Exception
    {
        public string NumPlate { get; }
        public string BrokenRules { get; }

        public QuestionAlreadyExistsException(string numPlate)
        {
          NumPlate = numPlate;
        }

        public QuestionAlreadyExistsException(string numPlate, string brokenRules)
        {
            NumPlate = numPlate;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Question with Num Plate:{NumPlate} already Exists!\n" +
                                          $" Additional info:{BrokenRules}";
    }
}
