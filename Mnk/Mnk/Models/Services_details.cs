using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Services_details
    {
        [Key]
        public int Service_Detail_Id { get; set; }
        [Required]
        public string Service_Detail_Name { get; set; }
        [Required]
        public string Service_Detail_Description { get; set; }
        
        public string Service_Detail_Image { get; set; }
        public bool service_Status { get; set; }
        public DateTime service_Date { get; set; }

        public int Service_Id { get; set; }
        public virtual Services Services { get; set; }

    }
}