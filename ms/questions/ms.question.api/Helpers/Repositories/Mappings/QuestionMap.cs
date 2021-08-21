using FluentNHibernate.Mapping;
using ms.question.api.Helpers.Models;

namespace ms.question.api.Helpers.Repositories.Mappings
{
  public class QuestionMap : ClassMap<Question>
  {
    public QuestionMap()
    {
      Schema(@"public");
      Table(@"questions");
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

      Map(x => x.Body)
        .Column("`body`")
        .CustomType("string")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;


      Map(x => x.Views)
        .Column("`views`")
        .CustomType("int")
        .Access.Property()
        .Generated.Never()
        .Default(@"0")
        .Not.Nullable()
        ;

      Map(x => x.Flags)
        .Column("`flags`")
        .CustomType("int")
        .Access.Property()
        .Generated.Never()
        .Default(@"0")
        .Not.Nullable()
        ;

      Map(x => x.Votes)
        .Column("`votes`")
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
