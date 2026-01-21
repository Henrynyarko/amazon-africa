using Microsoft.EntityFrameworkCore;
using AmazonAfrica.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Debug: print environment
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

// Get connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        $"Connection string not found! Environment: {builder.Environment.EnvironmentName}. " +
        $"Make sure ASPNETCORE_ENVIRONMENT is set and appsettings.{builder.Environment.EnvironmentName}.json exists."
    );
}

// Get schema
string schema = builder.Configuration.GetValue<string>("Database:Schema") ?? "amazonafrica";

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", schema)
    )
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
