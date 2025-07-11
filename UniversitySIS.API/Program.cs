using Microsoft.EntityFrameworkCore;
using UniversitySIS.Application.Interfaces;
using UniversitySIS.Infrastructure.Persistence;
using UniversitySIS.Infrastructure.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=UniversitySISDB;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "University SIS API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "University SIS API V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
if (!Directory.Exists(uploadPath))
{
    Directory.CreateDirectory(uploadPath);
}

app.Run();
