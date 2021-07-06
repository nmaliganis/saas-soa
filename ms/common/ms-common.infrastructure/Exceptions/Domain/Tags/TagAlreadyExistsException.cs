using System;

namespace ms.common.infrastructure.Exceptions.Domain.Tags
{
    public class TagAlreadyExistsException : Exception
    {
        public string NumPlate { get; }
        public string BrokenRules { get; }

        public TagAlreadyExistsException(string numPlate)
        {
          NumPlate = numPlate;
        }

        public TagAlreadyExistsException(string numPlate, string brokenRules)
        {
            NumPlate = numPlate;
            BrokenRules = brokenRules;
        }

        public override string Message => $" Tag with Num Plate:{NumPlate} already Exists!\n" +
                                          $" Additional info:{BrokenRules}";
    }
}
