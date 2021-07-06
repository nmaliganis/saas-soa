using System;

namespace ms.common.infrastructure.Exceptions.Domain.Questions
{
  public class QuestionDoesNotExistAfterMadeTransientException : Exception
  {
    public int Id { get; private set; }

    public QuestionDoesNotExistAfterMadeTransientException(int id)
    {
      Id = id;
    }

    public override string Message => $" Question with Id:" +
                                      $" {Id} was not made Persistent!";
  }
}