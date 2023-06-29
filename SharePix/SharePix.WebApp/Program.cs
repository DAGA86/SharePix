using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SharePix.Data.Providers;
using System.Globalization;

namespace SharePix.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }
            ).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, (options) =>
            {
                options.LoginPath = "/UserAccounts/Login";
                options.LogoutPath = "/UserAccounts/Logout";
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
            }
            );

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<Data.Contexts.DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<LanguageProvider>();
            builder.Services.AddScoped<LocalizationProvider>();

            builder.Services.AddLocalization();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddViewLocalization();

            string[] cultures = new string[] { "en-US", "pt-PT" };
            var cultureInfos = cultures.Select(x => new CultureInfo(x)).ToArray();

            //language default request
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var englishCulture = cultureInfos.FirstOrDefault(x => x.Name == "en-US");
                options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-US");

                options.SupportedCultures = cultureInfos;
                options.SupportedUICultures = cultureInfos;
            });

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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=UserAccounts}/{action=Login}/{id?}");

            app.Run();
        }
    }
}