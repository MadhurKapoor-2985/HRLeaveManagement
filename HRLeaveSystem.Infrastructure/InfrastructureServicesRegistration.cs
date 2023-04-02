using HRLeaveSystem.Application.Contracts.Email;
using HRLeaveSystem.Application.Contracts.Logging;
using HRLeaveSystem.Application.Models;
using HRLeaveSystem.Infrastructure.EmailService;
using HRLeaveSystem.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveSystem.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            return services;
        }
    }
}