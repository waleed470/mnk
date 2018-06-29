using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class real_estate
    {
        [Key]
        public int real_id {get; set; }
        public string real_name { get; set; }
        public string real_discription { get; set; }
        public string real_image { get; set; }
        public bool real_status { get; set; }
        public DateTime real_date { get; set; }

    }
}