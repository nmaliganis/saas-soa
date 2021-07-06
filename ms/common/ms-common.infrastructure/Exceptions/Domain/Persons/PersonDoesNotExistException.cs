using System;

namespace ms.common.infrastructure.Exceptions.Domain.Persons
{
    public class PersonDoesNotExistException : Exception
    {
        public int PersonId { get; }

        public PersonDoesNotExistException(int personId)
        {
            PersonId = personId;
        }

        public override string Message => $"Person with Id:" +
                                          $" {PersonId}  doesn't exists!";
    }
}
