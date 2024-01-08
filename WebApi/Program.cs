using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreDbContext>(options =>
options.UseInMemoryDatabase("BookStoreDB"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
                              //<hangi sınıftan kalıtım aldı , hangi sınıf çalışacak>
//builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
builder.Services.AddSingleton<ILoggerService, DBLooger>();


// Build the app.
var app = builder.Build();

// Initialize data.
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
DataGenerator.Initialize(serviceProvider);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCustomExceptionMiddle();

app.MapControllers();
app.Run();

