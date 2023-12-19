
using BackendASP;
using BackendASP.Database;
using Microsoft.OpenApi.Models;
using System.Reflection;

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
            builder.Services.AddControllers()
                .AddNewtonsoftJson();
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