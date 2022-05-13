using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using publicApi.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using publicApi.Service.Interfaces;
using publicApi.Service;
using publicApi.Model.Profiles;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using publicApi.Service.ConfigurationOptions;
using System.Text;
using publicApi.Services;
using publicApi.Services.Interfaces;

namespace publicApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "publicApi", Version = "v1" });
            });
            services.AddAutoMapper(typeof(usuarioProfile));
           
            services.AddDbContext<DbUsuarioContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("db_usuario")));
            //DI
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, userService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ITaskService, TasksService>();

            //jwt
            var jsonWebTokenOptions = Configuration.GetSection(JsonWebTokenOptions.Section).Get<JsonWebTokenOptions>();

            services.AddSingleton(jsonWebTokenOptions);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jsonWebTokenOptions.Secret)),
                    ValidateIssuer = true,
                    ValidIssuer = jsonWebTokenOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudiences = new string[] { jsonWebTokenOptions.Audience }
                };
            });

            services.AddCors(op =>
               op.AddDefaultPolicy(
               builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "publicApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            
            app.UseAuthentication();
           
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
