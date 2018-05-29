using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board_Location
    {
        [Key]
        public int Board_Location_Id { get; set; }
        [Required]
        public string Board_location_name { get; set; }
        
        public bool Board_location_Status { get; set; }
        
        public DateTime Board_location_Date { get; set; }
    }
}