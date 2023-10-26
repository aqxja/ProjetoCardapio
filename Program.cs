using Microsoft.EntityFrameworkCore;
using ProjetoCardapio.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=SB-1490656\\SQLSENAI;Initial Catalog = ProjetoCardapio;Integrated Security = True;TrustServerCertificate = True"));*Aquiles/

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=SB-1490629\\SQLSENAI;Initial Catalog = ProjetoCardapio;Integrated Security = True;TrustServerCertificate = True"));*Vinicius/

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=SB-1490626\\SQLSENAI;Initial Catalog = ProjetoCardapio;Integrated Security = True;TrustServerCertificate = True"));*Kaique/

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Data Source=SB-1490652\\SQLSENAI;Initial Catalog = ProjetoCardapio;Integrated Security = True;TrustServerCertificate = True"));*Alue/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
