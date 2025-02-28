using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{
    public abstract class Aggregate<T> : Entity<T>, IAggregate<T>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent); 
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] domainEvents = _domainEvents.ToArray();
            return domainEvents;
        }
    }
}
