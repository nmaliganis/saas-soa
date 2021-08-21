using soa.common.infrastructure.Domain;

namespace ms.tag.api.Helpers.Models
{
    public class TagBusinessRules
    {
        public static BusinessRule Title => new BusinessRule("Tag", "Tag Title must not be null or empty!");
    }
}