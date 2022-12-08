using MusicApp.Core.Models.Album;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Contracts
{
    public interface IAlbumService
    {
        Task<IEnumerable<HomepageAlbumModel>> GetLastThreeAlbums();

        Task<AllAlbumsModel> GetAllAlbums(string? genre = null, string? searchTerm = null, AlbumsSorting sorting = AlbumsSorting.Newest, int currentPage = 1, int albumsPerPage = 1 );

        Task<IEnumerable<AlbumModel>> GetAllUserAlbums(string userId);

        Task<IEnumerable<Genre>> GetGenres();

        Task<IEnumerable<AlbumGenreModel>> GetGenreModels();

        Task<AlbumDetailsModel> GetAlbumDetails(int albumId);

        Task<ICollection<Comment>> GetComments(int albumId);

        Task AddComent(int albumId, string userId, Comment comment);

        Task<int> AddAlbum(AddAlbumModel model, string userId);

        Task<bool> IsAlbumAddedByUser(int albumId, string userId);
    }
}
