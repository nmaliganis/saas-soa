using FluentNHibernate.Mapping;
using ms.category.api.Helpers.Models;
using soa.qa.model.Categories;

namespace ms.category.api.Helpers.Repositories.Mappings
{
  public class CategoryMap : ClassMap<Category>
  {
    public CategoryMap()
    {
      Schema(@"public");
      Table(@"categories");
      LazyLoad();

      Id(x => x.Id)
        .Column("id")
        .CustomType("int")
        .Access.Property()
        .Not.Nullable()
        .GeneratedBy
        .Increment()
        ;

      Map(x => x.Name)
        .Column("`name`")
        .CustomType("string")
        .Unique()
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
