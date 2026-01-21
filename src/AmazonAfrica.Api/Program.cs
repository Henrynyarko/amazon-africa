var builder = WebApplication.CreateBuilder(args);

// Add services for controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger everywhere
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

app.Run();
