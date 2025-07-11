using UniversitySIS.Application.DTOs;

namespace UniversitySIS.Application.Interfaces
{
    public interface IStudentService
    {
        Task<Guid> CreateStudentAsync(CreateStudentDto studentDto);
        Task<StudentDto?> GetStudentByIdAsync(Guid id);
        Task<bool> UpdateStudentPhotoPathAsync(Guid id, string filePath);
        Task<bool> UpdateStudentAsync(Guid id, CreateStudentDto dto);
        Task<bool> DeleteStudentAsync(Guid id);
        Task<List<StudentDto>> GetAllStudentsAsync();
    }
}
