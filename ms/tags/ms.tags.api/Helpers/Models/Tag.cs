using System;
using System.Collections.Generic;
using soa.common.infrastructure.Domain;

namespace ms.tag.api.Helpers.Models
{
  public class Tag : EntityBase<int>, IAggregateRoot
  {
    public Tag()
    {
      OnCreated();
    }
    public virtual string Title { get; set; }
    public virtual string Description { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual bool Active { get; set; }

    public virtual int QuestionId { get; set; }

    private void OnCreated()
    {
      this.Active = true;
      this.CreatedDate = DateTime.Now;
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

