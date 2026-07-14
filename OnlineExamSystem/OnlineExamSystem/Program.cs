using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineExamSystem.Data;
using OnlineExamSystem.Helpers;
using OnlineExamSystem.Repositories.Implementations;
using OnlineExamSystem.Repositories.Interfaces;
using OnlineExamSystem.Services;
using OnlineExamSystem.Services.Implementations;
using OnlineExamSystem.Services.Interfaces;
using System.Text;
using OfficeOpenXml;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// JWT

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options =>
{

    options.TokenValidationParameters =new TokenValidationParameters
    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,


        ValidIssuer =builder.Configuration["Jwt:Issuer"],


        ValidAudience = builder.Configuration["Jwt:Audience"],


        IssuerSigningKey =new SymmetricSecurityKey(
                                  Encoding.UTF8.GetBytes(
                                  builder.Configuration["Jwt:Key"]))

    };

});



builder.Services.AddAuthorization();



// Dependency Injection

builder.Services.AddScoped<JwtHelper>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IExcelImportService,ExcelImportService>();
builder.Services.AddScoped<IStudentExamRepository, StudentExamRepository>();

builder.Services.AddScoped<IStudentExamService, StudentExamService>();
builder.Services.AddEndpointsApiExplorer();
ExcelPackage.License.SetNonCommercialPersonal("Hepsiba");

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
