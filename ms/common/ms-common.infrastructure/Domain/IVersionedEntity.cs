namespace ms.common.infrastructure.Domain
{
    public interface IVersionedEntity
    {
        int Revision { get; set; }
    }
}