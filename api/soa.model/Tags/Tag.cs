using System;
using soa.common.infrastructure.Domain;

namespace soa.model.Tags
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

