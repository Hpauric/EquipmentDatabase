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
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Equipment>()
            //    .HasOptional<Student>(s => s.Student)
            //    .WithMany()
            //    .HasForeignKey(s => s.StudentID)
            //    .WillCascadeOnDelete();

            //modelBuilder.Entity<Student>()
            //.HasOptional<Standard>(s => s.Standard)
            //.WithMany()
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Equipment>()
            //    .HasKey(o => o.StudentID).
            //    .WillCascadeOnDelete(true);

        }
    }
}
