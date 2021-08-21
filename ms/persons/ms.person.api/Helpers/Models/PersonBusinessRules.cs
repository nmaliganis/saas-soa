using soa.common.infrastructure.Domain;

namespace ms.person.api.Helpers.Models
{
    public class PersonBusinessRules
    {
        public static BusinessRule Email => new BusinessRule("Person", "Person Email must not be null or empty!");
        public static BusinessRule Firstname => new BusinessRule("Person", "Person Firstname must not be null or empty!");
        public static BusinessRule Lastname => new BusinessRule("Person", "Person Lastname must not be null or empty!");
    }
}