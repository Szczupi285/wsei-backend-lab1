using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Memory;
using Infrastructure.Memory.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using WebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IntGenerator>();
builder.Services.AddDbContext<QuizDbContext>();
//builder.Services.AddSingleton<IGenericRepository<Quiz, int>, MemoryGenericRepository<Quiz, int>>();
//builder.Services.AddSingleton<IGenericRepository<QuizItem, int>, MemoryGenericRepository<QuizItem, int>>();
//builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>, MemoryGenericRepository<QuizItemUserAnswer, string>>();
//builder.Services.AddSingleton<IQuizAdminService, QuizAdminService>();
//builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
builder.Services.AddTransient <IQuizUserService, QuizUserServiceEF>();
builder.Services.AddScoped<IValidator<QuizItem>, QuizItemValidator>();
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
