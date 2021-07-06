using ms.common.infrastructure.Domain;
using soa.common.infrastructure.Domain;

namespace soa.model.Questions
{
    public class QuestionBusinessRules
    {
        public static BusinessRule Title => new BusinessRule("Question", "Question Title must not be null or empty!");
        public static BusinessRule Body => new BusinessRule("Question", "Question Body must not be null or empty!");
    }
}