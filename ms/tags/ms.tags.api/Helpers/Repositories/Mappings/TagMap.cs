using FluentNHibernate.Mapping;
using ms.tag.api.Helpers.Models;

namespace ms.tag.api.Helpers.Repositories.Mappings
{
  public class TagMap : ClassMap<Tag>
  {
    public TagMap()
    {
      Schema(@"public");
      Table(@"Tags");
      LazyLoad();

      Id(x => x.Id)
        .Column("id")
        .CustomType("int")
        .Access.Property()
        .Not.Nullable()
        .GeneratedBy
        .Increment()
        ;

      Map(x => x.Title)
        .Column("`title`")
        .CustomType("string")
        .Unique()
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;

      Map(x => x.Description)
        .Column("`description`")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
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
