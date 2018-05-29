using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mnk.Models
{
    public class Gallery
    {
        [Key]
        public int Gallery_Id { get; set; }
        [Required]
        public string Gallery_title { get; set; }
        
        public string Gallery_image { get; set; }
        [Required]
        public bool Gallery_status { get; set; }
        [Required]
        public DateTime Gallery_date { get; set; }
    }
}