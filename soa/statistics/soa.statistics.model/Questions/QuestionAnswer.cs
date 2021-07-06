using System;
using soa.common.infrastructure.Domain;
using soa.model.Answers;

namespace soa.model.Questions
{
  public class QuestionAnswer : EntityBase<int>
  {
    public QuestionAnswer()
    {
      OnCreated();
    }

    private void OnCreated()
    {
      this.CreatedDate = DateTime.Now;
    }

    public virtual DateTime CreatedDate { get; set; }
    public virtual Question Question { get; set; }
    public virtual Answer Answer { get; set; }

    protected override void Validate()
    {
    }
  }
}

