using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManagementSystem.Application.Extension
{
    public static class ApplicationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            //register Mediator
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(assembly);
            });
            //register AutoMapper
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
        }
    }
}
