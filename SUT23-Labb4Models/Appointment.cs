using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb4Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int Id { get; set; }
    }
}
