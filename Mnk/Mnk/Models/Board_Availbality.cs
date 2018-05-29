using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board_Availbality
    {
        [Key]
        public int Availability_id { get; set; }
        [Required]
        public string Availability_name { get; set; }
        [Required]
        public DateTime Availability_to { get; set; }
        [Required]
        public DateTime Availability_from { get; set; }

        public bool Availability_status { get; set; }

        public DateTime Availability_Date { get; set; }
    }
}