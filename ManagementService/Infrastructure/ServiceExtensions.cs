using ManagementService.Application.Contracts;
using ManagementService.Domain.ExhibitionProposals;
using ManagementService.Domain.Members;
using ManagementService.Infrastructure.Domain.MeetingGroupProposals;
using ManagementService.Infrastructure.Domain.Members;
using ManagementService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementService.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration != null)
        {
            services.AddDbContext<ManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        services.AddTransient<IExhibitionProposalsRepository, ExhibitionProposalRepository>();
        services.AddTransient<IMemberRepository, MemberRepository>();
        services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>(x => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IEventBus, EventBus>();
        services.AddHostedService<EventReceiverService>();

        return services;
    }
}
