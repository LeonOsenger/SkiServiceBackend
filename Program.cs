using Microsoft.EntityFrameworkCore;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServiceAuftragService, ServiceAuftragDBService>();

// Add services to the container. 
builder.Services.AddDbContext<SkiServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB1")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
