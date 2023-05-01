using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.Repository;
using N3U1P9_HFT_2022231.Logic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using N3U1P9_HFT_2022231.Endpoint.Services;

namespace N3U1P9_HFT_2022231.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ShelterDbContext>();

            services.AddTransient<IRepository<Shelter>, ShelterRepository>();
            services.AddTransient<IRepository<Animal>, AnimalRepository>();
            services.AddTransient<IRepository<ShelterWorker>, ShelterWorkerRepository>();

            services.AddTransient<IShelterLogic, ShelterLogic>();
            services.AddTransient<IAnimalLogic, AnimalLogic>();
            services.AddTransient<IShelterWorkerLogic, ShelterWorkerLogic>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shelter.Endpoint", Version = "v1" });
            });

            services.AddSignalR();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shelter.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
