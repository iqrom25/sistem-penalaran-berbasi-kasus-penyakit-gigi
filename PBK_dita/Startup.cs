using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using PBK_dita.Models;
using PBK_dita.Repositories;
using PBK_dita.Services.Admin.Dashboard;
using PBK_dita.Services.Admin.Gejala;
using PBK_dita.Services.Admin.Penyakit;
using PBK_dita.Services.Admin.Rekam_Medis;
using PBK_dita.Services.Auth;
using PBK_dita.Services.Konsultasi;
using PBK_dita.Services.Riwayat_Konsultasi;
using PBK_dita.Services.User;
using PBK_dita.Utils;

namespace PBK_dita
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>  
                    {  
                        options.LoginPath = "/Auth/Index";
                        options.AccessDeniedPath = "/Auth/Forbidden";
                    });
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNToastNotifyToastr();
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseMySQL(Configuration.GetConnectionString("DefaultConnectionMySql"));
            });
            
            services.AddHttpContextAccessor();

            #region Repository inject
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Penyakit>, Repository<Penyakit>>();
            services.AddTransient<IRepository<Gejala>, Repository<Gejala>>();
            services.AddTransient<IRepository<RekamMedis>, Repository<RekamMedis>>();
            services.AddTransient<IRepository<RiwayatKonsultasi>, Repository<RiwayatKonsultasi>>();
            #endregion
            
            #region Services inject
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPenyakitService, PenyakitService>();
            services.AddTransient<IGejalaService, GejalaService>();
            services.AddTransient<IRekamMedisService, RekamMedisService>();
            services.AddTransient<IKonsultasiService, KonsultasiService>();
            services.AddTransient<IRiwayatKonsultasiService, RiwayatKonsultasiService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDashboardService, DashboardService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Auth/NotFound";
                    await next();
                }
            });
            app.UseStaticFiles();

            app.UseNToastNotify();
            
            app.UseAuthentication();
            
            app.UseCookiePolicy();
            
            app.UseRouting();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
