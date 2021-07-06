using System;

namespace ms.common.infrastructure.Exceptions.Domain.Persons
{
    public class PersonAlreadyExistsException : Exception
    {
        public string NumPlate { get; }
        public string BrokenRules { get; }

        public PersonAlreadyExistsException(string numPlate)
        {
          NumPlate = numPlate;
        }

        public PersonAlreadyExistsException(string numPlate, string brokenRules)
        {
            NumPlate = numPlate;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Person with Num Plate:{NumPlate} already Exists!\n" +
                                          $" Additional info:{BrokenRules}";
    }
}
