using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class slider
    {
        [Key]
        public int Slider_Id { get; set; }
        [Required]
        public string Slider_Title { get; set; }
        [Required]
        public string Slider_Image { get; set; }
        [Required]
        public bool Slider_Status { get; set; }
        [Required]
        public DateTime Slider_Date { get; set; }
    }
}