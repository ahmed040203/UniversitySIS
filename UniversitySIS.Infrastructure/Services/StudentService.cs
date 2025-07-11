using Microsoft.EntityFrameworkCore;
using UniversitySIS.Application.DTOs;
using UniversitySIS.Application.Interfaces;
using UniversitySIS.Domain.Entities;
using UniversitySIS.Infrastructure.Persistence;

namespace UniversitySIS.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateStudentAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                NationalId = dto.NationalId,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }

        public async Task<bool> UpdateStudentPhotoPathAsync(Guid id, string filePath)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            student.ProfilePicturePath = filePath;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentDto?> GetStudentByIdAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                NationalId = student.NationalId,
                FullName = student.FullName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address
            };
        }
        
        public async Task<bool> UpdateStudentAsync(Guid id, CreateStudentDto dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            student.FullName = dto.FullName;
            student.NationalId = dto.NationalId;
            student.Email = dto.Email;
            student.PhoneNumber = dto.PhoneNumber;
            student.Address = dto.Address;
            student.DateOfBirth = dto.DateOfBirth;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();

            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                NationalId = s.NationalId,
                FullName = s.FullName,
                Email = s.Email,
                DateOfBirth = s.DateOfBirth,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address
            }).ToList();
        }
    }
}
