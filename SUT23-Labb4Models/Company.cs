using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb4Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
