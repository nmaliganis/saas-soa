using System;
using soa.common.infrastructure.Domain;
using soa.model.Questions;

namespace soa.model.Tags
{
  public class TagQuestion : EntityBase<int>
  {
    public TagQuestion()
    {
      OnCreated();
    }
    public virtual Question Question { get; set; }
    public virtual Tag Tag { get; set; }
    public virtual DateTime CreatedDate { get; set; }


    private void OnCreated()
    {
      this.CreatedDate = DateTime.Now;
    }
    protected override void Validate()
    {
    }
  }
}

