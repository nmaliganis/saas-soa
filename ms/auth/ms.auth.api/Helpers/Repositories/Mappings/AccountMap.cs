using FluentNHibernate.Mapping;
using ms.auth.api.Helpers.Models;

namespace ms.auth.api.Helpers.Repositories.Mappings
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Schema(@"public");
            Table(@"Accounts");
            LazyLoad();

            Id(x => x.Id)
                .Column("id")
                .CustomType("int")
                .Access.Property()
                .Not.Nullable()
                .GeneratedBy
                .Increment()
                ;

            Map(x => x.Username)
                .Column("`username`")
                .CustomType("string")
                .Unique()
                .Access.Property()
                .Generated.Never()
                .Not.Nullable()
                ;
        }
    }
}