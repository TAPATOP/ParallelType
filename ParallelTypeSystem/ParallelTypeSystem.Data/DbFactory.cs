namespace ParallelTypeSystem.Data
{
    public class DbFactory : IDbFactory
    {
        ParallelTypeSystemDbContext dbContext;

        public ParallelTypeSystemDbContext GetContext()
        {
            return dbContext ?? (dbContext = new ParallelTypeSystemDbContext());
        }
    }
}
