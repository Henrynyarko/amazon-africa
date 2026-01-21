using Microsoft.EntityFrameworkCore;
using AmazonAfrica.Api.Data;
using AmazonAfrica.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add PostgreSQL DB context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Enable Swagger everywhere
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
