using System;
using API.Data;
using API.Interface;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
    IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
          {
              opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
          }
        );
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        // Add CORS
        services.AddCors(options =>
     {
         options.AddPolicy("AllowAngularDevClient", policy =>
         {
             policy.WithOrigins(

                     "http://localhost:4200",
                     "https://localhost:4200")

                  .AllowAnyHeader()
                  .AllowAnyMethod();
         });
     });
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

}
