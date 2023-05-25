using HotelManager.BLL.Extensions;
using HotelManager.DAL.Configurations;
using HotelManager.DAL.Entities;
using HotelManager.DAL.Seed;
using HotelManger.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace HotelManger.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(opts =>
            {
                var defaultConn = builder.Configuration.GetConnectionString("DefaultConnection");

                opts.UseSqlServer(defaultConn, x => x.MigrationsAssembly("HotelManager.DAL")
                );

            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, //for development, true when u get to prod
                ValidateAudience = false, //for development, true when u get to prod
                RequireExpirationTime = false,//for development,  when u get to prod implement refresh token 
                ValidateLifetime = true
            };


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })

               .AddJwtBearer(jwt =>
               {
                   jwt.SaveToken = true;
                   jwt.TokenValidationParameters = tokenValidationParameters;
               });

            builder.Services.AddSingleton(tokenValidationParameters);

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 104857600; // 100 MB
            });

            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hotel Manager API",
                    Description = "An ASP.NET Core Web Backend API For Managing Hotels",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                // using System.Reflection;
               /* var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));*/
            });
            builder.Services.AddAutoMapper(Assembly.Load("HotelManager.BLL"));
            builder.Services.RegisterServices();
            builder.Services.AddHttpContextAccessor();

          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI( c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.yaml","Hotel Manager");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.AddGlobalErrorHandler();
            app.UseCors("CorsPolicy");
          await  SeedData.EnsurePopulatedAsync(app);

            app.Run();
        }
    }
}