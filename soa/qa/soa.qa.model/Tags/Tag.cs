using System;
using System.Collections.Generic;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.Domain;

namespace soa.qa.model.Tags
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
    public virtual ISet<TagQuestion> TagQuestions { get; set; }


    private void OnCreated()
    {
      this.Active = true;
      this.CreatedDate = DateTime.Now;
      this.TagQuestions = new HashSet<TagQuestion>();
    }


    public virtual void SoftDeleted()
    {
      this.Active = true;
    }

    protected override void Validate()
    {
    }

    public virtual void InjectWithInitialAttributes(TagForCreationUiModel newTagUiModel)
    {
        this.Title = newTagUiModel.Title;
        this.Description = newTagUiModel.Description;
    }

    public virtual void InjectWithInitialModifiedAttributes(TagForModificationUiModel updatedTag)
    {
        this.Title = updatedTag.Title;
        this.Description = updatedTag.Description;
        }
  }
}

