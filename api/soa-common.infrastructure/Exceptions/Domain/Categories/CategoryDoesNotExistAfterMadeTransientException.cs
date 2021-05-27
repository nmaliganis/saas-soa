using System;

namespace soa.common.infrastructure.Exceptions.Domain.Categories
{
  public class CategoryDoesNotExistAfterMadeTransientException : Exception
  {
    public int Id { get; private set; }

    public CategoryDoesNotExistAfterMadeTransientException(int id)
    {
      Id = id;
    }

    public override string Message => $" Category with Id:" +
                                      $" {Id} was not made Persistent!";
  }
}