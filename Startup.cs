using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Education
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
            
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //action server to create a token
                    ValidateAudience = true,
                    ValidateLifetime = true, //Token has not expired
                    ValidateIssuerSigningKey = true, //SigningKey is trasted by the server
                    ValidIssuer = "https://localhost:44308/",
                    ValidAudience = "https://localhost:44308/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))

                };
            });
            //end authentification code 1 
            services.AddMvc();
            services.AddControllers();
            //start code for file
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //end code for file

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Education", Version = "v1" });
            });

            //start add code for migration
            services.AddDbContext<DbContextApplication>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ArticleDbConnection")));
            services.AddCors();
            //end add code for migration
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           

            app.UseCors(options => 
             options.WithOrigins("http://localhost:4200")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowAnyOrigin()
             );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Education v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //start authentification code 2

            app.UseAuthentication();

            //end authentification code 2

            app.UseAuthorization();
            //start code for file
            app.UseStaticFiles();
            //end code for file

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
