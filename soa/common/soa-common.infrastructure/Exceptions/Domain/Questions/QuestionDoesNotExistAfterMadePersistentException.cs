using System;

namespace soa.common.infrastructure.Exceptions.Domain.Questions
{
    public class QuestionDoesNotExistAfterMadePersistentException : Exception
    {
        public string NumPlate { get; private set; }

        public QuestionDoesNotExistAfterMadePersistentException(string numPlate)
        {
            NumPlate = numPlate;
        }

        public override string Message => $" Question with Num Plate:" +
                                          $" {NumPlate} was not made Persistent!";
    }
}