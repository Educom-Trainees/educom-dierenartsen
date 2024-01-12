
using BackendASP;
using BackendASP.Database;
using BackendASP.Models;
using JsonPatchSample;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Backend2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                        policy =>
                        {
                            policy.AllowAnyOrigin() // WithOrigins("http://localhost:8080")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
            });
            // Add services to the container.
            builder.Services.AddDbContext<PetCareContext>();

            builder.Services
                .AddIdentity<User, IdentityRole<int>>(options =>
                    {
                        options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Lockout.AllowedForNewUsers = false;
                    })
                .AddEntityFrameworkStores<PetCareContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddIdentityServer()
                .AddApiAuthorization<User, PetCareContext>();

            builder.Services
                .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                            ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
                            RoleClaimType = ClaimTypes.Role
                        };
                    }); 


            builder.Services.AddControllers(options =>
            {
                options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PetCare API",
                    Description = "An ASP.NET Core Web API for managing Pet Care items",
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddTransient<IEmailService, EmailService>();

            // Enable serving static files from the wwwroot folder
            builder.Services.AddDirectoryBrowser();

            var app = builder.Build();

            // Enable Swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            /*    // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwaggerUI();
                }
    */
            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            // Enable serving static files
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDirectoryBrowser();
            app.MapFallbackToFile("index.html");

            app.MapControllers();

            app.Run();
        }
    }
}