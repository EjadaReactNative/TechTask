
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Data;
using TechnicalTask.Services;

namespace TechnicalTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("AuthDb"));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddSingleton<IAuthService, AuthService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
