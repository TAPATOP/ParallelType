using System.Data.Entity;
using ParallelTypeSystem.Models.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;
using ParallelTypeSystem.Data.Migrations;

namespace ParallelTypeSystem.Data
{
    public class ParallelTypeSystemDbContext : IdentityDbContext<User>
    {
        public virtual IDbSet<File> Files { get; set; }
        public virtual IDbSet<FileVersion> FileVersions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
        public virtual DbSet<UsersFile> UsersFiles { get; set; }

        public ParallelTypeSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ParallelTypeSystemDbContext, Configuration>());
        }

        public static ParallelTypeSystemDbContext Create()
        {
            return new ParallelTypeSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .HasRequired(c => c.Creator)
                .WithMany(p => p.CreatedFiles)
                .HasForeignKey(c => c.CreatorId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
