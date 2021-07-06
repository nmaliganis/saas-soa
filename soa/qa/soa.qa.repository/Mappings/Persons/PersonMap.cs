using FluentNHibernate.Mapping;
using soa.qa.model.Persons;
using soa.qa.model.Questions;

namespace soa.qa.repository.Mappings.Persons
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
      
      HasMany<Question>(x => x.Questions)
        .Access.Property()
        .AsSet()
        .Cascade.All()
        .LazyLoad()
        .Inverse()
        .Generic()
        .KeyColumns.Add("`person_id`", mapping => mapping.Name("`person_id`")
          .SqlType("int")
          .Not.Nullable())
        ;
    }
  }
}
