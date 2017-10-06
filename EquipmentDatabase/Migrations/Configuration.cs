namespace EquipmentDatabase.Migrations
{
    using CsvHelper;
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<EquipmentDatabase.DAL.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EquipmentDatabase.DAL.ProjectContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            //throw new Exception(assembly.ToString());

            string[] names = assembly.GetManifestResourceNames();
            string fullString = "";
            names.ToList().ForEach(i => fullString += (i.ToString()) + '\n');

            //throw new Exception(fullString);

            string resourceName = "EquipmentDatabase.Migrations.SeedData.STUDENT_MOCK_DATA.csv";
            
            //Debug.WriteLine(resourceName);
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    

                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var students = csvReader.GetRecords<EquipmentDatabase.Models.Student>().ToArray();
                    context.Students.AddOrUpdate(c => c.LastName, students);

                    
                }
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
