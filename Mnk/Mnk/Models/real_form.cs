using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class real_form
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string site_name { get; set; }
        [Required]
        public string area { get; set; }
        [Required]
        public string banner_size { get; set; }

        public bool status { get; set; }
    }
}