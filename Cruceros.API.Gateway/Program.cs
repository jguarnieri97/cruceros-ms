using Cruceros.API.Gateway.Client;
using Cruceros.API.Gateway.Services;

var mode = "PROD";
//var mode = "DEV";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRoomClient, RoomClient>();
builder.Services.AddScoped<IAutenticationClient, AutenticationClient>();
builder.Services.AddScoped<ICruceroService, CruceroService>();
builder.Services.AddScoped<IReservasClient, ReservasClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

if(mode == "PROD") app.UseAuthValidation();

app.MapControllers();

app.Run();
