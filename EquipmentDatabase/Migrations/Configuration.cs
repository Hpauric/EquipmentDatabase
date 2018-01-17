namespace EquipmentDatabase.Migrations
{
    using CsvHelper;
    using EquipmentDatabase.DAL;
    using EquipmentDatabase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed partial class Configuration : DbMigrationsConfiguration<EquipmentDatabase.DAL.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EquipmentDatabase.DAL.ProjectContext context)
        {
            //var students = new List<Student>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            //string[] names = assembly.GetManifestResourceNames();
            //string fullString = "";
            //names.ToList().ForEach(i => fullString += (i.ToString()) + '\n');
            //string resourceName = "EquipmentDatabase.Migrations.SeedData.STUDENT_MOCK_DATA.csv";

            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        students = csvReader.GetRecords<EquipmentDatabase.Models.Student>().ToList();
            //        context.Students.AddOrUpdate(c => c.LastName, students.ToArray());
            //    }
            //}


            var students = context.Students.ToList();

            var equipments = new List<Equipment>
            {
                new Equipment
                {
                    // enrollment details are taken from students and courses Lists
                    StudentID = students.Single(s => s.StudentID == 1006725).StudentID,
                    DatePurchased = new DateTime(2017, 1, 1),
                    DateAssigned = new DateTime(2017, 1, 1),
                    EquipmentType = "Laptop",
                    ModelName = "Latitude E5520",
                    ServiceTag = "IHRYPEA",
                    Password = "Password",
                    Notes = "battery issue - no battery is detected"
                },
                new Equipment
                {
                    // enrollment details are taken from students and courses Lists
                    StudentID = students.Single(s => s.StudentID == 1007171).StudentID,
                    DatePurchased = new DateTime(2017, 1, 1),
                    DateAssigned = new DateTime(2017, 1, 1),
                    EquipmentType = "Laptop",
                    ModelName = "Latitude E5520",
                    ServiceTag = "XSRKQTL",
                    Password = "Password",
                    Notes = "battery issue - no battery is detected"
                    },
                new Equipment { 
                // enrollment details are taken from students and courses Lists
                    StudentID = students.Single(s => s.StudentID == 1008021).StudentID,
                    DatePurchased = new DateTime(2017,1,1),
                    DateAssigned = new DateTime(2017,1,1),
                    EquipmentType = "Laptop",
                    ModelName = "Latitude E5520"},
                new Equipment { 
                // enrollment details are taken from students and courses Lists
                    StudentID = students.Single(s => s.StudentID == 1014357).StudentID,
                    DatePurchased = new DateTime(2017,1,1),
                    DateAssigned = new DateTime(2017,1,1),
                    EquipmentType = "Laptop",
                    ModelName = "Latitude E5520"}
            };

            


            string resourceName2 = "EquipmentDatabase.Migrations.SeedData.EQUIPMENT_MOCK_DATA2.csv";

            string testString = "hello";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName2))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                        CsvReader csvReader = new CsvReader(reader);
                        var equipments2 = csvReader.GetRecords<EquipmentDatabase.Models.TestClass>().ToArray();

                    foreach (TestClass e in equipments2)
                    {
                       // testString = testString.Insert(0, e.EquipmentType + Environment.NewLine);
                        equipments.Add(new Equipment
                        {
                            StudentID = students.Single(s => s.StudentID == e.StudentID).StudentID,
                            DatePurchased = new DateTime(2017, 1, 1),
                            DateAssigned = new DateTime(2017, 1, 1),
                            EquipmentType = e.EquipmentType,
                            ModelName = e.ModelName,
                            Location = e.Location,
                            Status = e.Status,
                            Software = e.Software,
                            ServiceTag = e.ServiceTag,
                            Password = e.Password,
                            Notes = e.Notes
                        });

                    }

                    

                    foreach (Equipment e in equipments)
                    {
                        context.Equipments.Add(e);
                        
                    }
                    
                    //context.Equipments.AddOrUpdate(c => c.StudentID, equipments.ToArray());
                    //   for(var i = 0; i < 10; i++)
                    //{
                    //    testString = testString.Insert(0, testString + System.Environment.NewLine);
                    //}
                    //throw new Exception(testString);

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
