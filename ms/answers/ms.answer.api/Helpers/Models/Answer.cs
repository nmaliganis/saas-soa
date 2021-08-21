using System;
using System.Collections.Generic;
using soa.common.infrastructure.Domain;

namespace ms.answer.api.Helpers.Models
{
    public class Answer : EntityBase<int>, IAggregateRoot
    {
        public Answer()
        {
            OnCreated();
        }
        public virtual string Body { get; set; }
        public virtual int Views { get; set; }
        public virtual int Flags { get; set; }
        public virtual int Votes { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Active { get; set; }
        public virtual Answer Parent { get; set; }
        public virtual ISet<Answer> SubAnswers { get; set; }
        public virtual int QuestionId { get; set; }

        private void OnCreated()
        {
            this.Active = true;
            this.SubAnswers = new HashSet<Answer>();
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