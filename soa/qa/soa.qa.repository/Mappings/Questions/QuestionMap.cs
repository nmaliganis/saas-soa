using FluentNHibernate.Mapping;
using soa.qa.model.Categories;
using soa.qa.model.Persons;
using soa.qa.model.Questions;

namespace soa.qa.repository.Mappings.Questions
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

      References(x => x.Person)
        .Class<Person>()
        .Access.Property()
        .Cascade.None()
        .LazyLoad()
        .Columns("`person_id`")
        ;
      
      References(x => x.Category)
        .Class<Category>()
        .Access.Property()
        .Cascade.None()
        .LazyLoad()
        .Columns("`category_id`")
        ;

      HasMany<QuestionAnswer>(x => x.QuestionAnswers)
        .Access.Property()
        .AsSet()
        .Cascade.All()
        .LazyLoad()
        .Inverse()
        .Generic()
        .KeyColumns.Add("`question_id`", mapping => mapping.Name("`question_id`")
          .SqlType("int")
          .Not.Nullable())
        ;
    }
  }
}
