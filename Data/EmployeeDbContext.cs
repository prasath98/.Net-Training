using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employees has one to many relationship with Skillmap
            modelBuilder.Entity<SkillMap>().HasKey(sc => new { sc.EmployeeId, sc.SkillId });

            modelBuilder.Entity<SkillMap>()
                .HasOne<Employees>(sc => sc.Employees)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.EmployeeId);


            modelBuilder.Entity<SkillMap>()
                .HasOne<Skills>(sc => sc.Skills)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.SkillId);
            //Employees has one to many relationship with SoftLock
            modelBuilder.Entity<SoftLock>()
               .HasOne(bc => bc.Employees)
               .WithMany(b => b.SoftLocks)
               .HasForeignKey(bc => bc.EmployeeId);


        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SkillMap> SkillMaps { get; set; }
        public DbSet<SoftLock> SoftLocks { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Core.ViewModel.Employee> Employee { get; set; }
    }
}