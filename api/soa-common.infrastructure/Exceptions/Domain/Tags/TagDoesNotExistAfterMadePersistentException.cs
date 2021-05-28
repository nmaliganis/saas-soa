using System;

namespace soa.common.infrastructure.Exceptions.Domain.Tags
{
    public class TagDoesNotExistAfterMadePersistentException : Exception
    {
        public string NumPlate { get; private set; }

        public TagDoesNotExistAfterMadePersistentException(string numPlate)
        {
            NumPlate = numPlate;
        }

        public override string Message => $" Tag with Num Plate:" +
                                          $" {NumPlate} was not made Persistent!";
    }
}