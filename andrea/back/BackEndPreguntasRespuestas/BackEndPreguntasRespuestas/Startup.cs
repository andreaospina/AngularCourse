using AutoMapper;
using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Persistence.Context;
using BackEndPreguntasRespuestas.Persistence.Repositories;
using BackEndPreguntasRespuestas.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BackEndPreguntasRespuestas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("Conexion")));

            //service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICuestionarioService, CuestionarioService>();
            services.AddScoped<IRespuestaCuestionarioService, RespuestaCuestionarioService>();

            //repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICuestionarioRespository, CuestionarioRepository>();
            services.AddScoped<IRespuestaCuestionarioRepository, RespuestaCuestionarioRepository>();

            // Cors
            services.AddCors(options => options.AddPolicy("AllowWebApp",builder => 
                            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            //Add Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling
                                                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PreguntasRespuestas", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
        } 

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowWebApp");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoinds =>
            {
                endpoinds.MapControllers();
            });
        }
    }
}
