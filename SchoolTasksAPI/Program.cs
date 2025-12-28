using SchoolTasks.Core;           // בשביל IDataContext
using SchoolTasks.Data;           // בשביל DataContext
using SchoolTasks.Core.Services;  // בשביל Services Interfaces
using SchoolTasks.Service;        // בשביל Services Implementations
using Microsoft.EntityFrameworkCore; // חובה בשביל UseSqlServer

var builder = WebApplication.CreateBuilder(args);

// --- רישום השירותים (Dependency Injection) ---

// 1. הגדרת מסד הנתונים (מחליף את ה-Singleton הישן!)
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SchoolTasks.Data") // <--- הוספנו את השורה הזו!
    ));

// 2. גישור: כדי שמי שמבקש IDataContext יקבל את ה-DataContext שכבר יצרנו למעלה
builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

// 3. רישום ה-Services (הלוגיקה העסקית)
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

// --- סוף רישום השירותים ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();