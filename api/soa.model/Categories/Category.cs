using System;
using soa.common.infrastructure.Domain;

namespace soa.model.Categories
{
  public class Category : EntityBase<int>, IAggregateRoot
  {
    public Category()
    {
      OnCreated();
    }
    public virtual string Name { get; set; }
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

