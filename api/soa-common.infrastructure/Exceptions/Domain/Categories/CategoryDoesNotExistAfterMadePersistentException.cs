using System;

namespace soa.common.infrastructure.Exceptions.Domain.Categories
{
    public class CategoryDoesNotExistAfterMadePersistentException : Exception
    {
        public string NumPlate { get; private set; }

        public CategoryDoesNotExistAfterMadePersistentException(string numPlate)
        {
            NumPlate = numPlate;
        }

        public override string Message => $" Category with Num Plate:" +
                                          $" {NumPlate} was not made Persistent!";
    }
}