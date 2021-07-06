using soa.common.infrastructure.Domain;

namespace soa.qa.model.Answers
{
    public class AnswerBusinessRules
    {
        public static BusinessRule Title => new BusinessRule("Answer", "Answer Title must not be null or empty!");
        public static BusinessRule Body => new BusinessRule("Answer", "Answer Body must not be null or empty!");
    }
}