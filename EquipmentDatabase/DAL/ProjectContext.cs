using EquipmentDatabase.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EquipmentDatabase.DAL
{
    public class ProjectContext : DbContext
    {

        public ProjectContext() : base("ProjectContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}