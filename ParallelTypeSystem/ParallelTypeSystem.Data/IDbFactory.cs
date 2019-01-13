namespace ParallelTypeSystem.Data
{
    public interface IDbFactory
    {
        ParallelTypeSystemDbContext GetContext();
    }
}
