using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string JobRole { get; set; }

        [Required]
        public string Gender { get; set; }
        public bool FirstAppointment { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
