// using Microsoft.EntityFrameworkCore;
// using AmazonAfrica.Api.Data;

// var builder = WebApplication.CreateBuilder(args);

// // Configure EF Core with PostgreSQL
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseHttpsRedirection();

// app.MapControllers();

// app.Run();

using Microsoft.EntityFrameworkCore;
using AmazonAfrica.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
