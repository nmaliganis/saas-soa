using System;
using soa.common.infrastructure.Domain;

namespace soa.auth.api.Helpers.Models
{
    public class Account : EntityBase<int>, IAggregateRoot
    {
        public Account()
        {
            OnCreated();
        }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
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