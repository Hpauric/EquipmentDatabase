﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipmentDatabase.Models
{
    public class LoadingClass
    {

        public string EquipmentType { get; set; }
        public string ModelName { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Software { get; set; }
        public string ServiceTag { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
        public int? StudentID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePurchased { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAssigned { get; set; }


    }
}


