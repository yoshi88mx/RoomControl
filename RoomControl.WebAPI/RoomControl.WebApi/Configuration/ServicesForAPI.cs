using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomControl.Bussines.Services;
using RoomControl.Core.Contracts;
using RoomControl.Data;

namespace RoomControl.Shared.Configuration
{
    public static class ServicesForAPI
    {
        public static IServiceCollection AddServicesForAPI(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CHContext>(op => op.UseSqlServer(Configuration.GetConnectionString("SQL")).EnableSensitiveDataLogging());

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddMvc()
                .AddFluentValidation(op => op.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddTransient<IServiceQueues, ServiceQueues>();
            services.AddTransient<IServiceRooms, ServiceRooms>();
            services.AddTransient<IServiceRoomsTypes, ServiceRoomType>();
            services.AddTransient<IServiceRoomsPrices, ServiceRoomsPrices>();
            services.AddTransient<IServiceRoomsStates, ServiceRoomsStates>();
            services.AddTransient<IServiceRoomHistory, ServiceRoomHistory>();
            services.AddTransient<IServiceQueueImages, ServiceQueueImages>();
            services.AddTransient<IServiceConfiguration,ServiceConfiguration>();
            services.AddTransient<IServiceDisplayHistorye, ServiceDisplayHistoryes>();

            services.AddCors(op => op.AddDefaultPolicy(y =>
            {
                y.AllowAnyOrigin(); 
                y.AllowAnyMethod(); 
                y.AllowAnyHeader();
            }));

            return services;
        }
    }
}