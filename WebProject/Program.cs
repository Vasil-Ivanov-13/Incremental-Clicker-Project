using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;
using WebProject.Services;
using WebProject.Services.Interfaces;

namespace WebProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<WebProjectDbContext>(options =>
                options.UseSqlServer(connectionString));
            //  builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                   
                    options.SignIn.RequireConfirmedAccount = false;
                    //removing most password requirements.
                    options.Password.RequireDigit = false;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<WebProjectDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddScoped<ICombatService, CombatService>();
            builder.Services.AddScoped<IShopService, ShopService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
            app.MapRazorPages();

            app.Run();
        }
    }
}
