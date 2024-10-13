using _2024_2C_EstacionamientoORT.Data;
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
