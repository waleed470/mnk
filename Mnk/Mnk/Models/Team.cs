using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Team
    {
        [Key]
        public int Team_Member_Id { get; set; }
        [Required]
        public string Team_member_Name { get; set; }
        [Required]
        public string Team_member_Designation { get; set; }
        
        public string Team_member_image { get; set; }
        [Required]
        public bool Team_member_status { get; set; }
        [Required]
        public DateTime Team_member_date { get; set; }
    }
}