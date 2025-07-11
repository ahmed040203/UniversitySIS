using Microsoft.AspNetCore.Mvc;
using UniversitySIS.Application.DTOs;
using UniversitySIS.Application.Interfaces;

namespace UniversitySIS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { message = "Student not found." });

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _studentService.CreateStudentAsync(dto);
            return Ok(new { StudentId = id });
        }

        [HttpPost("{id}/upload-photo")]
        public async Task<IActionResult> UploadProfilePicture(Guid id, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file uploaded." });

            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { message = "Student not found." });

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _studentService.UpdateStudentPhotoPathAsync(id, $"Uploads/{fileName}");

            return Ok(new { message = "File uploaded successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.UpdateStudentAsync(id, dto);
            if (!result)
                return NotFound(new { message = "Student not found." });

            return Ok(new { message = "Student updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
                return NotFound(new { message = "Student not found." });

            return Ok(new { message = "Student deleted successfully." });
        }

    }
}
