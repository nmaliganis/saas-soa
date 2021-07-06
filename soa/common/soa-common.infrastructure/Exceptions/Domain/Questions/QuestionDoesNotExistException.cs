using System;

namespace soa.common.infrastructure.Exceptions.Domain.Questions
{
    public class QuestionDoesNotExistException : Exception
    {
        public int QuestionId { get; }

        public QuestionDoesNotExistException(int questionId)
        {
            QuestionId = questionId;
        }

        public override string Message => $"Question with Id:" +
                                          $" {QuestionId}  doesn't exists!";
    }
}
