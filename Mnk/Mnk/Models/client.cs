using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class client
    {
        [Key]
        public int Client_Id { get; set; }
        [Required]
        public string Client_name { get; set; }

        public string Client_image { get; set; }
        
        public bool Client_status { get; set; }
        
        public DateTime Client_date { get; set; }
    }
}
