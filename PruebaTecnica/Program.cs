using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Otros servicios...
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del pipeline de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
