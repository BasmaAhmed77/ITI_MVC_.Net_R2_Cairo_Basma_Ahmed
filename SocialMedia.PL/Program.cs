using Microsoft.EntityFrameworkCore;
using SocialMedia.BLL.Services.Abstraction;
using SocialMedia.BLL.Services.Implementation;
using SocialMedia.DAL.Database;
using SocialMedia.DAL.Repo.Abstraction;
using SocialMedia.DAL.Repo.Implementation;
using SocialMedia.BLL.Mapper;
using SocialMedia.DAL.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SocialMedia.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSession();
            builder.Services.AddSession(op =>
                op.IdleTimeout = TimeSpan.FromMinutes(59)
            );




            var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

            builder.Services
                .AddDbContext<SocialMediaDbContext>(options => options
                .UseSqlServer(connectionString));

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<SocialMediaDbContext>();

            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseSession();

            //built in middleware:
            //app.Use(async (HttpContext, next) =>
            //{
            //    //Console.WriteLine("My first middleware");
            //    //await next.Invoke();
            //    HttpContext.Response.Cookies.Append("org", "ITI");
            //    //await HttpContext.Response.WriteAsync("My first middleware");
            //    await next.Invoke();

            //});

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Register}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
