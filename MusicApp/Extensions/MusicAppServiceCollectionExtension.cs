using HouseRentingSystem.Infrastructure.Data.Common;
using MusicApp.Core.Contracts;
using MusicApp.Core.Services;
using MusicApp.Infrastructure.Common;
namespace Microsoft.Extensions.DependencyInjection;

public static class MusicAppServiceCollectionExtension
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
        services.AddScoped<ICommentService, CommentService>();

        return services;
    }
}
