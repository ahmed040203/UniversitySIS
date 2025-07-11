using System.ComponentModel.DataAnnotations;

namespace UniversitySIS.Application.DTOs
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "National ID is required.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must be 14 digits.")]
        public string NationalId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;
    }
}
