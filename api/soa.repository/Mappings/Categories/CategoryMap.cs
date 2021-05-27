using FluentNHibernate.Mapping;
using soa.model.Categories;

namespace soa.repository.Mappings.Categories
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

      //References(x => x.Owner)
      //  .Class<Owner>()
      //  .Access.Property()
      //  .Cascade.None()
      //  .LazyLoad()
      //  .Columns("`owner_id`")
      //  ;

      //HasMany<Session>(x => x.Sessions)
      //  .Access.Property()
      //  .AsSet()
      //  .Cascade.All()
      //  .LazyLoad()
      //  .Inverse()
      //  .Generic()
      //  .KeyColumns.Add("`CategoryId`", mapping => mapping.Name("`CategoryId`")
      //    .SqlType("uuid")
      //    .Not.Nullable())
      //  ;
    }
  }
}
