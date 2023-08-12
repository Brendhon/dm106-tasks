using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Log configuration
builder.Services.AddLogging(loggingBuilder =>
 {
   loggingBuilder.AddConsole();
   loggingBuilder.AddDebug();
   loggingBuilder.AddAzureWebAppDiagnostics();
 });

// Add database context
builder.Services.AddDbContext<TaskContext>(dbContextOptions => dbContextOptions
  .UseSqlServer(builder.Configuration["ConnectionStrings:AZURE_SQL_CONNECTION"])); // Connection string from Azure SQL

// Add services
builder.Services.AddScoped<TaskService>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  // Enable swagger for development mode
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
