using _2024_2C_EstacionamientoORT.Data;
using _2024_2C_EstacionamientoORT.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _2024_2C_EstacionamientoORT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configurar el contexto de base de datos en memoria
            //builder.Services.AddDbContext<EstacionamientoContext>(options =>
            //    options.UseInMemoryDatabase("EstacionamientoDb"));
            
            //Configuro SQL Server
            ////Agrego la base de datos SQL , y guardo el conection string en el appsetting.json
            builder.Services.AddDbContext<EstacionamientoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EstacionamientoDBCS")));
            
            
            var app = builder.Build();

            #region Identity
            //se Almacena en nuestro Contexto
            builder.Services.AddIdentity<Persona, Rol>().AddEntityFrameworkStores<EstacionamientoContext>();
            //Customizacion de Password
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
            }
            );

            //builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
            //                   options =>
            //                   {
            //                       options.LoginPath = "/Account/IniciarSesion";
            //                       options.AccessDeniedPath = "/Account/AccesoDenegado";
            //                   }
            //                              );

            //Password por defecto = Password1
            #endregion
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
