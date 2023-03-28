using Application;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Contextos;
using Persistence.Contratos;
using Persistence.Migrations;

namespace Api
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
            services.AddDbContext<OperationContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default")));

            services.AddControllers();
            services.AddScoped<IOperationTypeService, OperationTypeService>();
            services.AddScoped<IOperationTypePersist, OperationTypePersist>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IdentityCard, IdentityCard>();
            services.AddScoped<IIdentityCardPersist, IdentityCardPersist>();
            services.AddScoped<IIdentityCardService, IdentityCardService>();
            services.AddScoped<IPersonPersist, PersonPersist>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IOperationPersist, OperationPersist>();
            services.AddScoped<ICarLoadPersist, CarLoadPersist>();
            services.AddScoped<IClientPersist, ClientPersist>();
            services.AddScoped<IDestinationPersist, DestinationPersist>();
            services.AddScoped<IMaterialTypePersist, MaterialTypePersist>();
            services.AddScoped<IMaterialPersist, MaterialPersist>();
            services.AddScoped<IMaterialTypeService, MaterialTypeService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<ICarLoadService, CarLoadService>();
            services.AddScoped<IMaterialService, MaterialService>();

            services.AddCors();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}