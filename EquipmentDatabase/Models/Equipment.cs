using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentDatabase.Models
{

    public class Equipment
    {
        public int EquipmentID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePurchased { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAssigned { get; set;   }
        [Required]
        public string EquipmentType { get; set; }
        
        public string ModelName { get; set; }
        public string Location { get; set; }

        public int? StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}