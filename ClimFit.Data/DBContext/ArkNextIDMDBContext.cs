using ClimFit.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClimFit.Data.DBContext
{
    public class ClimFitDBContext : DbContext
    {
        #region DBSets
        public DbSet<TestPerson> TestPerson { get; set; }
        public DbSet<TestDepartment> TestDepartment { get; set; }
   

        #endregion

        public ClimFitDBContext(DbContextOptions<ClimFitDBContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
