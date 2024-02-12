using Lab3zadanie.Models;
using Lab3___zadanieContextConnection.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab3___zadanieContextConnection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Lab3zadanie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Lab3___zadanieContextConnection") 
                                   ?? throw new InvalidOperationException("Connection string 'Lab3___zadanieContextConnection' not found.");

            builder.Services.AddRazorPages();                         
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Lab3___zadanieContextConnection.AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()       
                .AddEntityFrameworkStores<Lab3___zadanieContextConnection.AppDbContext>();
            builder.Services.AddTransient<IEmployeeService, EFEmployeeService>();
            builder.Services.AddTransient<IEmployeeService, EFEmployeeService>();
            builder.Services.AddMemoryCache();                        
            builder.Services.AddSession();                               
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}