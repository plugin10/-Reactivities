using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection")); // this is the connection string to the database (DefaultConnection)
            });
            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"); // this is the policy that is used to allow requests from the client
                });
            });
            services.AddMediatR(typeof(List.Handler)); // this is the mediator that is used to send requests to the application

            services.AddAutoMapper(typeof(MappingProfiles).Assembly); // this is the automapper that is used to map the domain to the DTOs

            return services;
        }
    }
}