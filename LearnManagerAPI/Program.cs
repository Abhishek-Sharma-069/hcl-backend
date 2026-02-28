using Microsoft.EntityFrameworkCore;
using LearnManagerAPI.Data;
using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// add services
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// database (Postgres)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// application services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// error handling middleware
app.UseMiddleware<LearnManagerAPI.Middleware.ExceptionMiddleware>();

app.UseCors("AllowAll");
app.MapControllers();
app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

