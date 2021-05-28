using System;

namespace soa.common.infrastructure.Exceptions.Domain.Persons
{
    public class PersonDoesNotExistAfterMadePersistentException : Exception
    {
        public string NumPlate { get; private set; }

        public PersonDoesNotExistAfterMadePersistentException(string numPlate)
        {
            NumPlate = numPlate;
        }

        public override string Message => $" Person with Num Plate:" +
                                          $" {NumPlate} was not made Persistent!";
    }
}