namespace DynamicAuth.Repository.Implimentation
{
    public class UnitOfWork : IUnitOfWork
    {
    
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
