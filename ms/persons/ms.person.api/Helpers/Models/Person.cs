using System;
using System.Collections.Generic;
using soa.common.dtos.Vms.Persons;
using soa.common.infrastructure.Domain;
using soa.qa.model.Questions;

namespace soa.qa.model.Persons
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
    public virtual ISet<Question> Questions { get; set; }

    private void OnCreated()
    {
      this.Active = true;
      this.Flaged = 0;
      this.Voted = 0;
      this.CreatedDate = DateTime.Now;
      this.Questions = new HashSet<Question>();
    }


    public virtual void SoftDeleted()
    {
      this.Active = true;
    }

    protected override void Validate()
    {
    }

    public virtual void InjectWithInitialAttributes(PersonForCreationUiModel personToBeCreated)
    {
      this.Lastname = personToBeCreated.Lastname;
      this.Firstname = personToBeCreated.Firstname;
      this.Email = personToBeCreated.Email;
    }

    public virtual void InjectWithInitialModifiedAttributes(PersonForModificationUiModel updatedPerson)
    {
      this.Lastname = updatedPerson.Lastname;
      this.Firstname = updatedPerson.Firstname;
      this.Email = updatedPerson.Email;

      if (updatedPerson.AddFlaged)
      {
        this.Flaged++;
      }
      if (updatedPerson.RemoveFlaged)
      {
        this.Flaged--;
      }
      if (updatedPerson.AddVoted)
      {
        this.Voted++;
      }
      if (updatedPerson.RemoveVoted)
      {
        this.Voted--;
      }
    }
  }
}

