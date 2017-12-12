using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentDatabase.Models
{

    public class Equipment
    {
        public int EquipmentID { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatePurchased { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAssigned { get; set; }
        public string EquipmentType { get; set; }
        public int? StudentID { get; set; }
        public string ModelName { get; set; }
    
        public virtual Student Student { get; set; }
    }
}