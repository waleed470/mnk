using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board
    {
        [Key]
        public int Broard_Id { get; set; }
        [Required]
        public string Broard_Site_code { get; set; }
        [Required]
        public string Broard_Traffic_from { get; set; }
        [Required]
        public string Broard_Traffic_to { get; set; }
        [Required]
        public int Broard_Width { get; set; }
        [Required]
        public int Broard_Height { get; set; }
        public DateTime Board_date { get; set; }



        public int Board_Medium_Id { get; set; }
        public virtual Board_medium Board_medium { get; set; }


        public int Board_City_Id { get; set; }
        public virtual Board_city Board_city { get; set; }


        public int Board_Location_Id { get; set; }
        public virtual Board_Location Board_Location { get; set; }





    }
}