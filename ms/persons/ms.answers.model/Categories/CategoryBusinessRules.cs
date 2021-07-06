using soa.common.infrastructure.Domain;

namespace soa.model.Categories
{
    public class CategoryBusinessRules
    {
        public static BusinessRule Name => new BusinessRule("Category", "Category Name must not be null or empty!");
    }
}