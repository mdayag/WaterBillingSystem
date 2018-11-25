using System;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;

namespace Web.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryManagement"));

            //services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("LibraryManagement"));

            services.AddDbContext<MyDbContext>(options =>
                                                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                                                    );

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

            services.AddScoped<IBarangayRepository, BarangayRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IBarangayService, BarangayService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddCors();
            services.AddMvc();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                                   .AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .AllowCredentials()
            );

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
