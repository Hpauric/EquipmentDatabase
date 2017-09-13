using System;
using System.Collections.Generic;

namespace EquipmentDatabase.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public DateTime? AssignedDate { get; set; }

        public virtual Student Student { get; set; }
    }
}