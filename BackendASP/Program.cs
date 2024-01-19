using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Services;
using JsonPatchSample;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                        policy.WithOrigins("http://localhost:8080") //Change for production!!
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });
            // Add services to the container.
            builder.Services.AddDbContext<PetCareContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PetCareDatabaseLocalDB"), sqlOptions =>
                {
                    // Additional configuration options, if needed
                    sqlOptions.EnableRetryOnFailure();
                    sqlOptions.CommandTimeout(60); // Set command timeout, if needed
                    sqlOptions.UseDateOnlyTimeOnly(); // Use this for DateOnly and TimeOnly types
                });
            });

            builder.Services
                .AddIdentity<User, IdentityRole<int>>(options =>
                {
                    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier; ;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Lockout.AllowedForNewUsers = false;
                })
                .AddEntityFrameworkStores<PetCareContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.Cookie.Name = "token";
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        RoleClaimType = ClaimTypes.Role
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];
                            return Task.CompletedTask;
                        }
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
            builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

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