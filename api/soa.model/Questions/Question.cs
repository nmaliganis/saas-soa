using System;
using soa.common.infrastructure.Domain;

namespace soa.model.Questions
{
  public class Question : EntityBase<int>, IAggregateRoot
  {
    public Question()
    {
      OnCreated();
    }
    public virtual string Title { get; set; }
    public virtual string Body { get; set; }
    public virtual int Views { get; set; }
    public virtual int Flags { get; set; }
    public virtual int Votes { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual bool Active { get; set; }

    private void OnCreated()
    {
      this.Active = true;
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

