namespace UniversitySIS.Domain.Entities
{
    public class Student
    {
        public string? ProfilePicturePath { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NationalId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // أكتر من خاصية ممكن نضيفها لاحقًا زي:
        // public string Gender { get; set; }
        // public string Status { get; set; } // active/inactive

    }
}
