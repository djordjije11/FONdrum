using FluentValidation;
using FluentValidation.AspNetCore;
using FONdrum.DTO.Models;
using FONdrum.DTO.Request;
using FONdrum.DTO.Validation.Models.Orders;
using FONdrum.DTO.Validation.Request;
using Microsoft.AspNetCore.Mvc;

namespace FONdrum.API.Registrars.ServiceRegistrars.Models
{
    public class ModelsValidationRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            RegisterFluentValidators(builder.Services);
            ConfigureFluentValidationModelStateBinding(builder.Services);
        }

        private static void RegisterFluentValidators(IServiceCollection services)
        {
            services.AddSingleton<IValidator<PageParams>, PageParamsValidator>();
            services.AddSingleton<IValidator<OrderItemDto>, OrderItemDtoValidator>();
            services.AddSingleton<IValidator<OrderDto>, OrderDtoValidator>();
        }

        private static void ConfigureFluentValidationModelStateBinding(IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();   //  binding FluentValidation validators and ModelState
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //  Removing ASP.NET default Validation filter so we could place ours
            });
        }
    }
}
