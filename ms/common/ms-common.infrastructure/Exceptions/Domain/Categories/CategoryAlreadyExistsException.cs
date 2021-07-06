using System;

namespace ms.common.infrastructure.Exceptions.Domain.Categories
{
    public class CategoryAlreadyExistsException : Exception
    {
        public string NumPlate { get; }
        public string BrokenRules { get; }

        public CategoryAlreadyExistsException(string numPlate)
        {
          NumPlate = numPlate;
        }

        public CategoryAlreadyExistsException(string numPlate, string brokenRules)
        {
            NumPlate = numPlate;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Category with Num Plate:{NumPlate} already Exists!\n" +
                                          $" Additional info:{BrokenRules}";
    }
}
