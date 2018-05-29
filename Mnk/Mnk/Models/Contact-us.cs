using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Contact_us
    {
        [Key]
        public int Contact_Id { get; set; }
        [Required]
        public int Contact_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Contact_email { get; set; }
        [Required]
        public int Contact_Message { get; set; }

    }
}