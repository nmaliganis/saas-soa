using FluentNHibernate.Mapping;
using ms.person.api.Helpers.Models;

namespace ms.person.api.Helpers.Repositories.Mappings
{
  public class PersonMap : ClassMap<Person>
  {
    public PersonMap()
    {
      Schema(@"public");
      Table(@"Persons");
      LazyLoad();

      Id(x => x.Id)
        .Column("id")
        .CustomType("int")
        .Access.Property()
        .Not.Nullable()
        .GeneratedBy
        .Increment()
        ;

      Map(x => x.Email)
        .Column("`email`")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.Lastname)
        .Column("`lastName`")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.Firstname)
        .Column("`firstName`")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.Flaged)
        .Column("`flaged`")
        .CustomType("int")
        .Access.Property()
        .Generated.Never()
        .Default(@"0")
        .Not.Nullable()
        ;

      Map(x => x.Voted)
        .Column("`voted`")
        .CustomType("int")
        .Access.Property()
        .Generated.Never()
        .Default(@"0")
        .Not.Nullable()
        ;

      Map(x => x.CreatedDate)
        .Column("`createdDate`")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.Active)
        .Column("active")
        .CustomType("bool")
        .Access.Property()
        .Generated.Never()
        .Default("true")
        .CustomSqlType("boolean")
        .Not.Nullable()
        ;
    }
  }
}
