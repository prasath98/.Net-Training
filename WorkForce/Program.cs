using Core.Abstraction.IEmployeeService;
using Core.Abstraction.ISoftLockService;
using Core.Abstraction.IUserService;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Service.EmployeeService;
using Service.SoftLockService;
using Service.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
builder.Services.AddScoped(typeof(ISoftLockService), typeof(SoftLockService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

builder.Services.AddDbContext<EmployeeDbContext>(
      options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

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
