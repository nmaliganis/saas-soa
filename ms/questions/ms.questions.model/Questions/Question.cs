using System;
using System.Collections.Generic;

namespace ms.questions.model.Questions
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
    public virtual Person Person { get; set; }
    public virtual Category Category { get; set; }
    
    public virtual ISet<QuestionAnswer> QuestionAnswers { get; set; }
    public virtual ISet<TagQuestion> TagQuestions { get; set; }

    
    private void OnCreated()
    {
      this.Active = true;
      this.Views = 0;
      this.Flags = 0;
      this.Votes = 0;
      this.CreatedDate = DateTime.Now;
      this.QuestionAnswers = new HashSet<QuestionAnswer>();
      this.TagQuestions = new HashSet<TagQuestion>();
    }


    public virtual void SoftDeleted()
    {
      this.Active = true;
    }

    protected override void Validate()
    {
    }

    public virtual void InjectWithInitialAttributes(QuestionForCreationUiModel newQuestionUiModel)
    {
      this.Title = newQuestionUiModel.Title;
      this.Body = newQuestionUiModel.Body;
    }

    public virtual void InjectWithCategory(Category categoryToBeInjected)
    {
      this.Category = categoryToBeInjected;
      categoryToBeInjected.Questions.Add(this);
    }

    public virtual void InjectWithPerson(Person personToBeInjected)
    {
      this.Person = personToBeInjected;
      personToBeInjected.Questions.Add(this);
    }
  }
}

