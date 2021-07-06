using System;

namespace ms.common.infrastructure.Exceptions.Domain.Tags
{
  public class TagDoesNotExistAfterMadeTransientException : Exception
  {
    public int Id { get; private set; }

    public TagDoesNotExistAfterMadeTransientException(int id)
    {
      Id = id;
    }

    public override string Message => $" Tag with Id:" +
                                      $" {Id} was not made Persistent!";
  }
}