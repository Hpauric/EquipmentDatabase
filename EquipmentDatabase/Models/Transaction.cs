using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipmentDatabase.Models
{

    public enum TransactionType
    {
        Assigned, Removed, Recycled, NoteAdded
    }

    public class Transaction
    {
        public int TransactionID { get; set; }
        public int EquipmentID { get; set; }
        public int? StudentID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note { get; set; }

        public virtual Student Student { get; set; }
        public virtual Equipment Equipment { get; set; }

    }
}