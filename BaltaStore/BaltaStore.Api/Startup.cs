using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BaltaStore.Infra.StoreContext.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.StoreContext.Services;
using BaltaStore.Infra.StoreContext.DataContexts;
using BaltaStore.Domain.StoreContext.Handlers;
using Swashbuckle.AspNetCore.Swagger;

namespace BaltaStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();


            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new Info { Title = "Balta Store", Version = "v1" });                
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Balta Store - V1");
            });

        }
    }
}
