using System;
using soa.common.infrastructure.Domain;

namespace soa.model.Persons
{
  public class Person : EntityBase<int>, IAggregateRoot
  {
    public Person()
    {
      OnCreated();
    }
    public virtual string Firstname { get; set; }
    public virtual string Lastname { get; set; }
    public virtual string Email { get; set; }

    public virtual int Flaged { get; set; }
    public virtual int Voted { get; set; }
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

