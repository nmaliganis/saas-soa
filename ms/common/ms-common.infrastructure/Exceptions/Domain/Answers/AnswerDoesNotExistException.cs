using System;

namespace ms.common.infrastructure.Exceptions.Domain.Answers
{
    public class AnswerDoesNotExistException : Exception
    {
        public int AnswerId { get; }

        public AnswerDoesNotExistException(int answerId)
        {
            AnswerId = answerId;
        }

        public override string Message => $"Answer with Id:" +
                                          $" {AnswerId}  doesn't exists!";
    }
}
