using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using prodi.Models;

namespace prodi
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
            #pragma warning disable CS0618 // Type or member is obsolete
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            #pragma warning restore CS0618 // Type or member is obsolete
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var context = serviceProvider.GetService<ApiContext>();
            InitialiseTestData(context);

            app.UseMvc();
        }

        /// <summary>
        /// Initialises the test data.
        /// </summary>
        /// <param name="context">The API's database context</param>
        internal static void InitialiseTestData(ApiContext context)
        {
            var product = new Product
            {
                Description = "AAA",
                Model = "CCC",
                Brand = "DDD"
            };
            context.Products.Add(product);

            product = new Product
            {
                Description = "BBB",
                Model = "CCC",
                Brand = "EEE"
            };
            context.Products.Add(product);

            product = new Product
            {
                Description = "BBB",
                Model = "CCC",
                Brand = "FFF"
            };
            context.Products.Add(product);

            context.SaveChanges();
        }
    }
}
