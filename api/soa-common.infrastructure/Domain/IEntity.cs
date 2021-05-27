namespace soa.common.infrastructure.Domain
{
    public interface IEntity<TId> : IVersionedEntity
    {
        TId Id { get; set; }
    }
}
