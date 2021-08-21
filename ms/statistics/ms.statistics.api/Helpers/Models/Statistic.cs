using System;
using soa.common.infrastructure.Domain;

namespace soa.statistics.api.Helpers.Models
{
    public class Statistic : EntityBase<int>, IAggregateRoot
    {
        public Statistic()
        {
            OnCreated();
        }

        public virtual string Body { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Active { get; set; }

        private void OnCreated()
        {
            this.Active = true;
            this.CreatedDate = DateTime.Now;
        }

        protected override void Validate()
        {
        }
    }
}