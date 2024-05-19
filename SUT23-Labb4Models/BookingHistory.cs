using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb4Models
{
    public class BookingHistory
    {
        [Key]
        public int Id { get; set; } 
        public int BookingId { get; set; }
        public DateTime? OldStartTime { get; set; } 
        public DateTime? OldEndTime { get; set; } 
        public DateTime NewStartTime { get; set; }
        public DateTime NewEndTime { get; set; }
        public DateTime ChangedAt { get; set; }
        public string ChangedBy { get; set; }
    }
}
