using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Data;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Data.Repositorios;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Servicios.Servicios;

namespace TiendaVirtualCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<NeptunoDbContext>(options=>options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRepositorioCategorias, RepositorioCategorias>();
            builder.Services.AddScoped<IServiciosCategorias,ServiciosCategorias>();

            builder.Services.AddScoped<IRepositorioPaises, RepositorioPaises>();
            builder.Services.AddScoped<IServiciosPaises,ServiciosPaises>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(typeof(Program));

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
        }
    }
}