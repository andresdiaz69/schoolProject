using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Domain.IRepository;
using SchoolWebAPI.Domain.IServices;
using SchoolWebAPI.Persistence.Context;
using SchoolWebAPI.Persistence.Repositories;
using SchoolWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolDbContext>(
    options => options.UseSqlServer
       (builder.Configuration.GetConnectionString("SchoolDB"))
    );
// Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IGradeService, GradeService>();

// Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();

// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp" ,
                                builder => builder.AllowAnyHeader()
                                                  .AllowAnyOrigin()
                                                  .AllowAnyMethod()
));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowWebApp");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
