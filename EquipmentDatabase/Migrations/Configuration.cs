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
            var equipments = new List<Equipment> {};
            string resourceName2 = "EquipmentDatabase.Migrations.SeedData.EQUIPMENT_MOCK_DATA2.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName2))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    var loadingData = csvReader.GetRecords<EquipmentDatabase.Models.LoadingClass>().ToArray();
                    foreach (LoadingClass l in loadingData)
                    {
                        Equipment myEquip = new Equipment
                        {
                            DatePurchased = l.DatePurchased,
                            DateAssigned = l.DateAssigned,
                            EquipmentType = l.EquipmentType,
                            ModelName = l.ModelName,
                            Location = l.Location,
                            Status = l.Status,
                            Software = l.Software,
                            ServiceTag = l.ServiceTag,
                            Password = l.Password,
                            Notes = l.Notes
                        };
                        if(l.StudentID != null)
                        {
                            myEquip.StudentID = students.Single(s => s.StudentID == l.StudentID).StudentID;
                        }
                        equipments.Add(myEquip);
                    }
                    foreach (Equipment e in equipments)
                    {
                        context.Equipments.Add(e);
                        context.SaveChanges();

                        Transaction newTransaction = new Transaction
                        {
                            EquipmentID = e.EquipmentID,
                            TransactionDate = e.DatePurchased,
                            TransactionType = TransactionType.Purchased
                        };
                        context.Transactions.Add(newTransaction);
                        context.SaveChanges();
                        if (e.StudentID != null)
                        {
                            var secondTransaction = newTransaction;
                            secondTransaction.StudentID = students.Single(s => s.StudentID == e.StudentID).StudentID;
                            secondTransaction.TransactionType = TransactionType.Assigned;
                            secondTransaction.TransactionDate = secondTransaction.TransactionDate.AddMonths(3);
                            context.Transactions.Add(secondTransaction);
                            context.SaveChanges();
                        }



                    }

                    Transaction removedTransaction = new Transaction
                    {
                        EquipmentID = equipments.ElementAt(4).EquipmentID,
                        StudentID = students.ElementAt(4).StudentID,
                        TransactionType = TransactionType.Removed,
                        TransactionDate = equipments.First<Equipment>().DatePurchased.AddMonths(1)
                    };
                    context.Transactions.Add(removedTransaction);
                    context.SaveChanges();

                }
            }
        }
    }
}
