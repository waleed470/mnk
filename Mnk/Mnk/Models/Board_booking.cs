using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mnk.Models
{
    public class Board_booking
    {
        [Key]
        public int Board_booking_id { get; set; }
        public string Booking_type { get; set; }
        public DateTime Booking_to { get; set; }
        public DateTime Booking_from { get; set; }
        
        public int Broard_Id { get; set; }
        public virtual Board Board { get; set; }

        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}