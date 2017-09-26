using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentDatabase.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Student Number")]
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}