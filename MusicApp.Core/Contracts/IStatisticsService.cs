using MusicApp.Core.Models.Statistics;

namespace MusicApp.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<IEnumerable<StatisticsAlbumModel>> Top3();
    }
}
