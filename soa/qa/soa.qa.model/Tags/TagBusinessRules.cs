using soa.common.infrastructure.Domain;

namespace soa.qa.model.Tags
{
    public class TagBusinessRules
    {
        public static BusinessRule Title => new BusinessRule("Tag", "Tag Title must not be null or empty!");
    }
}