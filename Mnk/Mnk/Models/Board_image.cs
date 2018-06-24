using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board_image
    {
        [Key]
        public int Board_image_id { get; set; }
        public string image { get; set; }


        public int Board_id { get; set; }
        public virtual Board Board { get; set; }
    }
}