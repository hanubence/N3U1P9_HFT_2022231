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
            services.AddSingleton<ShelterDbContext>();

            services.AddSingleton<IRepository<Shelter>, ShelterRepository>();
            services.AddSingleton<IRepository<Animal>, AnimalRepository>();
            services.AddSingleton<IRepository<ShelterWorker>, ShelterWorkerRepository>();

            services.AddSingleton<IShelterLogic, ShelterLogic>();
            services.AddSingleton<IAnimalLogic, AnimalLogic>();
            services.AddSingleton<IShelterWorkerLogic, ShelterWorkerLogic>();

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

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:41541", "http://localhost:60000"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
