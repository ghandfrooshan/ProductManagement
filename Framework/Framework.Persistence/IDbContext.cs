namespace Framework.Persistence
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        void Migrate();
        void ChangeDatabase(string connectionString);
        new void Dispose();
    }
}