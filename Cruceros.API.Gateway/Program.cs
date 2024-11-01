using Cruceros.API.Gateway.Client;
using Cruceros.API.Gateway.Service;
using Cruceros.API.Gateway.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRoomClient, RoomClient>();
builder.Services.AddScoped<IAutenticationClient, AutenticationClient>();

builder.Services.AddHttpClient<IRoomService, RoomService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5149"); // URL y puerto de la API interna
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthValidation();

app.MapControllers();

app.Run();
