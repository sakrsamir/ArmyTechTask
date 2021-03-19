using System.Data.Entity;

namespace ArmyTechTask.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("CenterDbContext")
        {
        }

        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fleunt API
            modelBuilder.Entity<Neighborhood>()
                .HasRequired(n => n.Governorate)
                .WithMany(n => n.Neighborhoods)
                .WillCascadeOnDelete(false);
        }
    }
}