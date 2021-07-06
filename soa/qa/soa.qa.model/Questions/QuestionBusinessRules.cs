using soa.common.infrastructure.Domain;

namespace soa.qa.model.Questions
{
    public class QuestionBusinessRules
    {
        public static BusinessRule Title => new BusinessRule("Question", "Question Title must not be null or empty!");
        public static BusinessRule Body => new BusinessRule("Question", "Question Body must not be null or empty!");
    }
}