using FluentNHibernate.Mapping;
using soa.qa.model.Categories;
using soa.qa.model.Questions;

namespace soa.qa.repository.Mappings.Categories
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

      HasMany<Question>(x => x.Questions)
        .Access.Property()
        .AsSet()
        .Cascade.All()
        .LazyLoad()
        .Inverse()
        .Generic()
        .KeyColumns.Add("`category_id`", mapping => mapping.Name("`category_id`")
          .SqlType("uuid")
          .Not.Nullable())
        ;
    }
  }
}
