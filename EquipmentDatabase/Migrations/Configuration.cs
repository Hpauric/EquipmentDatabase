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

            //void DeleteAllData(ProjectContext myContext)
            //{
            //    var equipmentsToDelete = myContext.Equipments.ToList();
            //    foreach (Equipment e in equipmentsToDelete)
            //    {
            //        context.Equipments.Remove(e);
            //    }
            //    var studentsToDelete = myContext.Students.ToList();
            //    foreach (Student s in studentsToDelete)
            //    {
            //        context.Students.Remove(s);
            //    }
            //}

            //DeleteAllData(context);

            var equipmentsToDelete = context.Equipments.ToList();
            foreach (Equipment e in equipmentsToDelete)
            {
                context.Equipments.Remove(e);
            }
            var studentsToDelete = context.Students.ToList();
            foreach (Student s in studentsToDelete)
            {
                context.Students.Remove(s);
            }
            context.SaveChanges();

            var students = new List<Student>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] names = assembly.GetManifestResourceNames();
            string fullString = "";
            names.ToList().ForEach(i => fullString += (i.ToString()) + '\n');
            string resourceName = "EquipmentDatabase.Migrations.SeedData.STUDENT_MOCK_DATA.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    students = csvReader.GetRecords<EquipmentDatabase.Models.Student>().ToList();
                    context.Students.AddOrUpdate(c => c.StudentID, students.ToArray());
                }
            }


            //var students = context.Students.ToList();

            var equipments = new List<Equipment> {};

            string resourceName2 = "EquipmentDatabase.Migrations.SeedData.EQUIPMENT_MOCK_DATA2.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName2))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                        CsvReader csvReader = new CsvReader(reader);
                        var equipments2 = csvReader.GetRecords<EquipmentDatabase.Models.TestClass>().ToArray();

                    foreach (TestClass e in equipments2)
                    {
                        //equipments.Add(new Equipment
                        //{
                        //    StudentID = students.Single(s => s.StudentID == e.StudentID).StudentID,
                        //    DatePurchased = new DateTime(2017, 1, 1),
                        //    DateAssigned = new DateTime(2017, 1, 1),
                        //    EquipmentType = e.EquipmentType,
                        //    ModelName = e.ModelName,
                        //    Location = e.Location,
                        //    Status = e.Status,
                        //    Software = e.Software,
                        //    ServiceTag = e.ServiceTag,
                        //    Password = e.Password,
                        //    Notes = e.Notes
                        //});

                        Equipment myEquip = new Equipment
                        {
                            DatePurchased = e.DatePurchased,
                            DateAssigned = e.DateAssigned,
                            EquipmentType = e.EquipmentType,
                            ModelName = e.ModelName,
                            Location = e.Location,
                            Status = e.Status,
                            Software = e.Software,
                            ServiceTag = e.ServiceTag,
                            Password = e.Password,
                            Notes = e.Notes
                        };

                        if(e.StudentID != null)
                        {
                            myEquip.StudentID = students.Single(s => s.StudentID == e.StudentID).StudentID;
                        }

                        equipments.Add(myEquip);

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
