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

    internal sealed class Configuration : DbMigrationsConfiguration<EquipmentDatabase.DAL.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EquipmentDatabase.DAL.ProjectContext context)
        {

            var students = context.Students.ToList();

            var equipments = new List<Equipment>
            {
                new Equipment { 
                // enrollment details are taken from students and courses Lists
                    StudentID = students.Single(s => s.StudentID == 1006725).StudentID,
                    DatePurchased = new DateTime(2017,1,1),
                    DateAssigned = new DateTime(2017,1,1),
                    EquipmentType = "Laptop",
                    ModelName = "Latitude E5520",
                    ServiceTag = "IHRYPEA",
                    Password = "Password",
                    Notes = "battery issue - no battery is detected"
                    },
                new Equipment { 
                // enrollment details are taken from students and courses Lists
                    StudentID = students.Single(s => s.StudentID == 1007171).StudentID,
                    DatePurchased = new DateTime(2017,1,1),
                    DateAssigned = new DateTime(2017,1,1),
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
            
            foreach (Equipment e in equipments)
            {
                e.Location = "Main Office";
                context.Equipments.Add(e);
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
