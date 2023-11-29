
using BackendASP.Database;

namespace Backend2
{
    public class Program
    {
        public static void Main(string[] args)
        {
/*            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";*/

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                        policy =>
                        {
                            policy.AllowAnyOrigin() // nog verder specificeren voor beveiligingpurposes
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
            });
            // Add services to the container.
            builder.Services.AddDbContext<PetCareContext>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

          /*  app.UseHttpsRedirection();*/

            app.UseCors();

            /*app.UseAuthorization();*/


            app.MapControllers();

            app.Run();
        }
    }
}