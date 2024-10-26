using Cruceros.API.Reservas.Repository;
using Cruceros.API.Reservas.Services;
using Cruceros.Data.Entidades;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReservasService, ReservasService>();
builder.Services.AddScoped<IReservasRepository, ReservasRepository>();

builder.Services.AddDbContext<CrucerosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection")));

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
