using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Contracts;
using MusicApp.Core.Services;
using MusicApp.Data;
using MusicApp.Infrastructure.Common;

namespace Microsoft.Extensions.DependencyInjection;

public static class MusicAppServiceCollectionExtension
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStatisticsService, StatisticsService>();

        return services;
    }

    public static IServiceCollection AddMusicAppDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<MusicAppDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddScoped<IRepository, Repository>();
        
        return services;
    }
}
