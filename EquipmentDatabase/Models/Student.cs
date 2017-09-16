using System;
using System.Collections.Generic;

namespace EquipmentDatabase.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}