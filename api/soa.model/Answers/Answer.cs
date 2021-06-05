using System;
using System.Collections.Generic;
using soa.common.infrastructure.Domain;
using soa.model.Questions;

namespace soa.model.Answers
{
  public class Answer : EntityBase<int>, IAggregateRoot
  {
    public Answer()
    {
      OnCreated();
    }
    public virtual string Body { get; set; }
    public virtual int Views { get; set; }
    public virtual int Flags { get; set; }
    public virtual int Votes { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual bool Active { get; set; }
    public virtual Answer Parent { get; set; }
    public virtual ISet<Answer> SubAnswers { get; set; }
    public virtual ISet<QuestionAnswer> QuestionAnswers { get; set; }

    private void OnCreated()
    {
      this.Active = true;
      this.SubAnswers = new HashSet<Answer>();
      this.QuestionAnswers = new HashSet<QuestionAnswer>();
    }


    public virtual void SoftDeleted()
    {
      this.Active = true;
    }

    protected override void Validate()
    {
    }
  }
}

