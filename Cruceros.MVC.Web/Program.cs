using Cruceros.Data.Entidades;
using Cruceros.MVC.Web.Client;
using Cruceros.MVC.Web.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar el contexto de base de datos CrucerosContext
builder.Services.AddDbContext<CrucerosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAutenticationClient, AutenticationClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
