using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeDisney.PreAcel.Context;
using AutoMapper;
using ChallengeDisney.PreAcel.Repositories;
using ChallengeDisney.PreAcel.Interfaces.Repositories;
using ChallengeDisney.PreAcel.Mapping;
using Microsoft.AspNetCore.Identity;
using ChallengeDisney.PreAcel.Entities;

namespace ChallengeDisney.PreAcel
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
            services.AddControllers();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChallengeDisney.PreAcel", Version = "v1" });
            });
            services.AddEntityFrameworkSqlServer();


            services.AddDbContextPool<WordDisneyContext>(optionsAction: (services, options) =>
            {

                options.UseInternalServiceProvider(services);
                string connection = "Data Source=(localdb)\\MSSQLLocalDB;Database=WordDinseyDb;Integrated Security=True;";
                options.UseSqlServer(connection);
            });
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
            // Inyecci�n de dependencia de repositorios:
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IMovieOrSerieRepository, MovieOrSerieRepository>();
            services.AddScoped<>
        
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChallengeDisney.PreAcel v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}




