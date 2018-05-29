using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class testo_nomia
    {
        [Key]
        public int Testo_nomia_Id { get; set; }
        [Required]
        public string Testo_nomia_name { get; set; }
        [Required]
        public string Testo_nomia_Massage { get; set; }
        public String Testo_nomia_image { get; set; }
        [Required]
        public DateTime testo_nomia_Date { get; set; }
    }
}