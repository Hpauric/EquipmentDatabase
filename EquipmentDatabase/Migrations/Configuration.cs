namespace EquipmentDatabase.Migrations
{
    using CsvHelper;
    using EquipmentDatabase.DAL;
    using System;
    using System.Data.Entity;
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


            //var equipments = context.Equipments.ToArray();
            //foreach (var item in equipments)
            //{
            //    //if(item.DatePurchased == null)
            //    //{
            //    //    item.DatePurchased = new DateTime(2017,1,1);
            //    //}
            //    if(item.StudentID != null)
            //    {
            ////        item.Location = "With Student";

            ////    }

                

            ////}
            //context.Equipments.AddOrUpdate(equipments);

            string[] names = assembly.GetManifestResourceNames();
            string fullString = "";
            names.ToList().ForEach(i => fullString += (i.ToString()) + '\n');

            //throw new Exception(fullString);

            //string resourceName = "EquipmentDatabase.Migrations.SeedData.STUDENT_MOCK_DATA.csv";
            
            ////Debug.WriteLine(resourceName);
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        var students = csvReader.GetRecords<EquipmentDatabase.Models.Student>().ToArray();
            //        //context.Students.AddOrUpdate(c => c.LastName, students);
            //        context.Students.AddOrUpdate(students);
            //    }
            //}

            string resourcename2 = "EquipmentDatabase.Migrations.SeedData.EQUIPMENT_MOCK_DATA.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourcename2))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var equipments2 = csvReader.GetRecords<EquipmentDatabase.Models.Equipment>().ToArray();
                    //context.Students.AddOrUpdate(c => c.LastName, students);

                    context.Equipments.AddOrUpdate(c => c.StudentID, equipments2);

                    //foreach (var item in equipments2)
                    //{
                    //    context.Entry(item.Student).State = EntityState.Unchanged;

                    //    context.
                    //    context.Students.Find(.State = EntityState.Unchanged;

                    //    context.Equipments.Add(item);

                    //    context.SaveChanges();
                    //}

                    //context.Entry(Equipments.StudentID).State = EntityState.Unchanged;

                    //context.Equipments.AddOrUpdate(equipments2);

                }
            }



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //public OrderLine AddOrUpdate(WindyContext context, OrderLine orderLine)
            //{
            //    var trackedOrderLine = context.OrderLines.Find(orderLine.OrderId, orderLine.ProductId);
            //    if (trackedOrderLine != null)
            //    {
            //        context.Entry(trackedOrderLine).CurrentValues.SetValues(orderLine);
            //        return trackedOrderLine;
            //    }

            //    context.OrderLines.Add(orderLine);
            //    return orderLine;
            //    //}
            //    private ProjectContext db = new ProjectContext();
            //var equipments = db.Equipments.Include(e => e.EquipmentID);

            //    //context.Equipments.AddOrUpdate(
            //    //  p => p.DatePurchased,
            //    //    { this.DatePurchased = "2007"}

            //);

        }
    }
}
