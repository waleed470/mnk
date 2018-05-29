using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board_city
    {
        [Key]
        public int Board_City_Id { get; set; }
        [Required]
        public string Board_City_name { get; set; }
        
        public bool Board_City_Status { get; set; }
        
        public DateTime Board_City_Date { get; set; }
    }
}