using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Services
    {
        [Key]
        public int Service_Id { get; set; }
        [Required]
        public string Service_Name { get; set; }
        [Required]
        public bool Service_status { get; set; }
        [Required]
        public DateTime Service_date { get; set; }
    }
}