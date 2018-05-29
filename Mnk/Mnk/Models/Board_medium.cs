using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board_medium
    {
        [Key]
        public int Board_Medium_Id { get; set; }
        [Required]
        public string Board_Medium_name { get; set; }
        
        public bool Board_Medium_Status { get; set; }
       
        public DateTime Board_Medium_Date { get; set; }
    }
}