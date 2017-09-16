using System;

namespace EquipmentDatabase.Models
{

    public class Equipment
    {
        public int EquipmentID { get; set; }
        public DateTime DateAssigned { get; set; }
        public string EquipmentName { get; set; }
        public int StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}