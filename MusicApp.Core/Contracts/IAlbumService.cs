using MusicApp.Core.Models.Album;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Contracts
{
    public interface IAlbumService
    {
        Task<IEnumerable<HomepageAlbumModel>> GetLastThreeAlbums();

        Task<AllAlbumsModel> GetAllAlbums(string? genre = null, string? searchTerm = null, AlbumsSorting sorting = AlbumsSorting.Newest, int currentPage = 1, int albumsPerPage = 1 );

        Task<AdminAreaAllAlbumsModel> AdminGetAllAlbums(string? genre = null, string? searchTerm = null, AlbumsSorting sorting = AlbumsSorting.Newest, bool isActive = true);

        Task<IEnumerable<AlbumModel>> GetAllUserAlbums(string userId);

        Task<IEnumerable<Genre>> GetGenres();

        Task<IEnumerable<AlbumGenreModel>> GetGenreModels();

        Task<AlbumDetailsModel> GetAlbumDetails(int albumId);

        Task<AlbumDetailsModel> AdminGetAlbumDetails(int albumId, bool isActive);

        Task<AddAlbumModel> GetAlbumDetailsToEdit(int albumId);

        Task<int> AddAlbum(AddAlbumModel model, string userId);

        Task<bool> IsAlbumAddedByUser(int albumId, string userId);

        Task LikeAlbum(int albumId, string userId);

        Task<bool> IsAlbumLikedByUser(int albumId, string userId);

        Task<Album> GetAlbum(int albumId);

        Task Edit(int albumId, string userId, AddAlbumModel model);

        Task Delete(int albumId, string userId);
    }
}
