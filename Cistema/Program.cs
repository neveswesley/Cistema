using System.Text.Json.Serialization;
using Cistema.Database;
using Cistema.Repositories;
using Cistema.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<CistemaDbContext>(options =>
{
    options.UseSqlServer("Server=WESLEY\\SQLEXPRESS;Database=Cistema.DB;User ID=sa;Password=1q2w3e4r5t@#;TrustServerCertificate=True;");
});
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();