using System.Data.Entity.Migrations;

namespace ParallelTypeSystem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ParallelTypeSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
