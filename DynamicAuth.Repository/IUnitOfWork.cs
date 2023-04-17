namespace DynamicAuth.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        void Commit();
    }
}
