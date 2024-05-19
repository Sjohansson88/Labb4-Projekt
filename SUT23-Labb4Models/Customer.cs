using System.ComponentModel.DataAnnotations;

namespace SUT23_Labb4Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
       
    }
}
