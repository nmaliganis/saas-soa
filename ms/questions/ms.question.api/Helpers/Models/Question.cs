using System;
using System.Collections.Generic;
using soa.common.infrastructure.Domain;

namespace ms.question.api.Helpers.Models
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
        public virtual int PersonId { get; set; }
        public virtual int CategoryId { get; set; }
    
        private void OnCreated()
        {
            this.Active = true;
            this.Views = 0;
            this.Flags = 0;
            this.Votes = 0;
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