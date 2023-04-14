using Enoca.Application.Repositories.Carrier;
using Enoca.Application.Repositories.CarrierConfiguration;
using Enoca.Application.Repositories.CarrierReport;
using Enoca.Application.Repositories.Order;
using Enoca.Application.Services;
using Enoca.Persistence.Contexts;
using Enoca.Persistence.Repositories.Carrier;
using Enoca.Persistence.Repositories.CarrierConfiguration;
using Enoca.Persistence.Repositories.CarrierReport;
using Enoca.Persistence.Repositories.Order;
using Enoca.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<EnocaDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Scoped);



            #region Repositories
            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
            services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
            services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICarrierReportReadRepository, CarrierReportReadRepository>();
            services.AddScoped<ICarrierReportWriteRepository, CarrierReportWriteRepository>();
            #endregion

            #region Services
            services.AddScoped<ICarrierService,CarrierService>();
            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<ICarrierReportService,CarrierResportService>();
            #endregion
        }
    }
}
