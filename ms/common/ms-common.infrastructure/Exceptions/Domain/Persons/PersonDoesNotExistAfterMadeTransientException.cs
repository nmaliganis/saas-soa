using System;

namespace ms.common.infrastructure.Exceptions.Domain.Persons
{
  public class PersonDoesNotExistAfterMadeTransientException : Exception
  {
    public int Id { get; private set; }

    public PersonDoesNotExistAfterMadeTransientException(int id)
    {
      Id = id;
    }

    public override string Message => $" Person with Id:" +
                                      $" {Id} was not made Persistent!";
  }
}