using Cruceros.API.Habitaciones.Repository;
using Cruceros.API.Habitaciones.Services;
using Cruceros.Data.Entidades;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHabitacionesService, HabitacionesService>();
builder.Services.AddScoped<IHabitacionesRepository, HabitacionesRepository>();

// Registrar el contexto de base de datos CrucerosContext
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
