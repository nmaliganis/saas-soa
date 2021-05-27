using FluentNHibernate.Mapping;
using soa.model.Answers;

namespace soa.repository.Mappings.Answers
{
  public class AnswerMap : ClassMap<Answer>
  {
    public AnswerMap()
    {
      Schema(@"public");
      Table(@"answers");
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

      References(x => x.Parent)
        .Class<Answer>()
        .Access.Property()
        .Cascade.None()
        .LazyLoad()
        .Columns("`parent_id`")
        ;

      HasMany<Answer>(x => x.SubAnswers)
        .Access.Property()
        .AsSet()
        .Cascade.All()
        .LazyLoad()
        .Inverse()
        .Generic()
        .KeyColumns.Add("`parent_id`", mapping => mapping.Name("`parent_id`")
          .SqlType("uuid")
          .Not.Nullable())
        ;
    }
  }
}
