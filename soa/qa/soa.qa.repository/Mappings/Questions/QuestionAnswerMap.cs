using FluentNHibernate.Mapping;
using soa.qa.model.Answers;
using soa.qa.model.Questions;

namespace soa.qa.repository.Mappings.Questions
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
