using System;
using System.Collections.Generic;
using soa.common.dtos.Vms.Categories;
using soa.common.infrastructure.Domain;
using soa.qa.model.Questions;

namespace soa.qa.model.Categories
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
    public virtual ISet<Question> Questions { get; set; }

    private void OnCreated()
    {
      this.Active = true;
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

    public virtual void InjectWithInitialAttributes(CategoryForCreationUiModel newCategoryUiModel)
    {
      this.Name = newCategoryUiModel.Name;
    }

    public virtual void InjectWithInitialModifiedAttributes(CategoryForModificationUiModel updatedCategory)
    {
      this.Name = updatedCategory.Name;
    }
  }
}

