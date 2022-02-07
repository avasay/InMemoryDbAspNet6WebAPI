
using InMemoryDbAspNet6WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeDBContext>(options => options.UseInMemoryDatabase("Employees"));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.UseCors(
        //options => options.WithOrigins("https://localhost:7067/").AllowAnyMethod() // Specific origin if this is what you want.
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("*")
);

app.MapControllers();

app.Run();
