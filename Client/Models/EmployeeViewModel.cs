using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [MaxLength(50, ErrorMessage = "Full Name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full Name can only contain letters and spaces")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job Role is required")]
        [Display(Name = "Job Role")]
        public string JobRole { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Display(Name = "First Appointment")]
        public bool FirstAppointment { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }
}
