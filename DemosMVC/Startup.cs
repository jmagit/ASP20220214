using Infraestructure.UoW;
using Domains.Contracts.DomainsServices;
using Domains.Contracts.Repositories;
using Domains.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemosMVC.Data;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using DemosMVC.Models.Validators;

namespace DemosMVC {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TiendaDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TiendaConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
#if DEBUG
            services.AddScoped<IProductoRepository, ProductoRepositoryMock>();
#else
            services.AddScoped<IProductoRepository, ProductoRepository>();
#endif
            services.AddTransient<IProductoService, ProductoService>();

            //services.AddRazorPages()
            //   .AddMvcOptions(options => {
            //       options.MaxModelValidationErrors = 50;
            //       options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            //           _ => "The field is required.");
            //   });
            services.AddSingleton<IValidationAttributeAdapterProvider, CustomValidationAttributeAdapterProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                //endpoints.MapControllerRoute(
                //    name: "informes",
                //    pattern: "admin/informe/{a�o}/{mes}/{tipo}",
                //    defaults: new { controller = "gererator", action = "infor" } );

                endpoints.MapControllerRoute(
                    name: "paginable",
                    pattern: "{controller=Home}/{pagina:int}/{rows:int:range(10,50)}",
                    defaults: new { action = "Pagina" });

                endpoints.MapControllerRoute(
                    name: "postaction",
                    pattern: "{controller=Home}/{id:int}/{action=Index}");
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "condetalles",
                    pattern: "{controller=Home}/{action=Index}/{id}/{**kk}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            var positionOptions = new PositionOptions();
            Configuration.GetSection(PositionOptions.Position).Bind(positionOptions);
            string userName = Configuration.GetSection("Position")["Name"];

        }
        public class PositionOptions {
            public const string Position = "Position";
            public string Title { get; set; }
            public string Name { get; set; }
        }


    }
}
