using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipmentDatabase.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public string EquipmentName { get; set; }
        public DateTime Purchased { get; set; }
        public Student StudentAssigned { get; set; }

    }
}