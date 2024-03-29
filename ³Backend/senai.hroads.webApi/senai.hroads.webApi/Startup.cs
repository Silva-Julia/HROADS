using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai.hroads.webApi
{
   public class Startup
        {
            // This method gets called by the runtime. Use this method to add services to the container.
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            public void ConfigureServices(IServiceCollection services)
            {
                // Define o uso de Controllers
                services
                    .AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hroads.webApi",
                    Version = "v1",
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            }
                );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao")),
                        ClockSkew = TimeSpan.FromMinutes(5),
                        ValidIssuer = "Hroads.webApi",
                        ValidAudience = "Hroads.webApi"
                    };
                });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai.Hroads.webApi");
                c.RoutePrefix = string.Empty;
            });


            // Habilita a autentica��o
            app.UseAuthentication();        // 401

            // Habilita a autoriza��o
            app.UseAuthorization();         // 403

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento dos Controllers.
                endpoints.MapControllers();
            });
        }

        // Scaffold-DbContext "Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; initial catalog=HROADS_TARDE; user Id=sa; pwd=senai@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context HroadsWeb

        // Comando:                                                 Scaffold-DbContext
        // String de conex�o:                                       "Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; initial catalog=inLockGames_tarde; user Id=sa; pwd=senai@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context InLockContext
        // Provedor de banco de dados utilizado:                    Microsoft.EntityFrameworkCore.SqlServer
        // Nome da pasta onde ficar�o os dom�nios:                  -OutputDir Domains
        // Nome da pasta onde ficar�o os contextos:                 -ContextDir Contexts
        // Nome do arquivo/classe de contexto:                      -Context HroadsWeb




    }
}
