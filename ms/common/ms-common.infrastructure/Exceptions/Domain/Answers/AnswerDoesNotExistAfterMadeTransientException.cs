using System;

namespace ms.common.infrastructure.Exceptions.Domain.Answers
{
  public class AnswerDoesNotExistAfterMadeTransientException : Exception
  {
    public int Id { get; private set; }

    public AnswerDoesNotExistAfterMadeTransientException(int id)
    {
      Id = id;
    }

    public override string Message => $" Answer with Id:" +
                                      $" {Id} was not made Persistent!";
  }
}