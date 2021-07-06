namespace ms.common.infrastructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();
        void Close();
    }
}
