using FluentNHibernate.Mapping;
using soa.model.Answers;
using soa.model.Categories;
using soa.model.Persons;
using soa.model.Questions;

namespace soa.repository.Mappings.Questions
{
  public class QuestionAnswerMap : ClassMap<QuestionAnswer>
  {
    public QuestionAnswerMap()
    {
      Schema(@"public");
      Table(@"questions_answers");
      LazyLoad();

      Id(x => x.Id)
        .Column("id")
        .CustomType("int")
        .Access.Property()
        .Not.Nullable()
        .GeneratedBy
        .Increment()
        ;

      Map(x => x.CreatedDate)
        .Column("`createdDate`")
        .CustomType("DateTime")
        .Access.Property()
        .Generated.Never()
        .Not.Nullable()
        ;
      
      References(x => x.Question)
        .Class<Question>()
        .Access.Property()
        .Cascade.None()
        .LazyLoad()
        .Columns("`question_id`")
        ;
      
      References(x => x.Answer)
        .Class<Answer>()
        .Access.Property()
        .Cascade.None()
        .LazyLoad()
        .Columns("`answer_id`")
        ;
    }
  }
}
