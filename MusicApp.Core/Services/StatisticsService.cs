using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Statistics;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repository;

        public StatisticsService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<StatisticsAlbumModel>> Top3()
        {
            return await repository
                .AllReadonly<Album>()
                .OrderByDescending(a => a.Likes)
                .Take(3)
                .Select(a => new StatisticsAlbumModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Genre = a.Genre,
                    Year = a.Year,
                    Likes = a.Likes
                })
                .ToListAsync();
        }
    }
}
