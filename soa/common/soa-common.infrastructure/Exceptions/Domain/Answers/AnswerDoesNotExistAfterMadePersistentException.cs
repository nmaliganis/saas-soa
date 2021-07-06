using System;

namespace soa.common.infrastructure.Exceptions.Domain.Answers
{
    public class AnswerDoesNotExistAfterMadePersistentException : Exception
    {
        public string NumPlate { get; private set; }

        public AnswerDoesNotExistAfterMadePersistentException(string numPlate)
        {
            NumPlate = numPlate;
        }

        public override string Message => $" Answer with Num Plate:" +
                                          $" {NumPlate} was not made Persistent!";
    }
}