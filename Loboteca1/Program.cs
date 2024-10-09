using Microsoft.EntityFrameworkCore;
using Loboteca1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agregar el contexto de la base de datos
builder.Services.AddDbContext<LobotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    pattern: "{controller=Login}/{action=Login}/{id?}");  // Ruta predeterminada para Login

// Definir rutas adicionales para cada controlador

//app.MapControllerRoute(
//    name: "estado",
//    pattern: "{controller=Estado}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "administrador",
//    pattern: "{controller=Administrador}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "alumno",
//    pattern: "{controller=Alumno}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "autor",
//    pattern: "{controller=Autor}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "autorlibro",
//    pattern: "{controller=AutorLibro}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "autorrevista",
//    pattern: "{controller=AutorRevista}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "carrera",
//    pattern: "{controller=Carrera}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
 //   endpoints.MapControllerRoute(
 //       name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});

app.MapControllerRoute(
    name: "editorial",
    pattern: "{controller=Editorial}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "elibro",
//    pattern: "{controller=ELibro}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "libro",
//    pattern: "{controller=Libro}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "prestamo",
//    pattern: "{controller=Prestamo}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "revista",
//    pattern: "{controller=Revista}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "sanciones",
//    pattern: "{controller=Sanciones}/{action=Index}/{id?}");

app.Run();
