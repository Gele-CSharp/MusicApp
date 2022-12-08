using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Core.Models.Comments;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository repository;

        public AlbumService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> AddAlbum(AddAlbumModel model, string userId)
        {
            var album = new Album()
            {
                Title = model.Title,
                Artist = model.Artist,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                GenreId = model.GenreId,
                Year = model.Year,
                UserId = userId
            };

            await repository.AddAsync<Album>(album);
            await repository.SaveChangesAsync();
            return album.Id;
        }

        public async Task AddComent(int albumId, string userId, Comment comment)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);
            comment.UserId = userId;
            comment.AlbumId = albumId;
            album.Comments.Add(comment);
            await repository.SaveChangesAsync();
        }

        public async Task<AlbumDetailsModel> GetAlbumDetails(int albumId)
        {
            var album = await repository
                .AllReadonly<Album>()
                .Where(a => a.IsActive && a.Id == albumId)
                .Include(a => a.User)
                .Include(a => a.Genre)
                .FirstAsync();

            var comments = await GetComments(albumId);

            return new AlbumDetailsModel()
            {
                Id = album.Id,
                Title = album.Title,
                Artist = album.Artist,
                ImageUrl = album.ImageUrl,
                Description = album.Description,
                GenreId = album.GenreId,
                Genre = album.Genre,
                UserId = album.UserId,
                User = album.User,
                Year = album.Year,
                Likes = album.Likes,
                Comments = new CommentModel()
                {
                    AlbumId = albumId,
                    Comments = comments
                }
            };
        }

        public async Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            var albums = await repository
                .AllReadonly<Album>()
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.Id)
                .Select(a => new AlbumModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();

            return albums;
        }

        public async Task<AllAlbumsModel> GetAllAlbums(string? genre = null, string? searchTerm = null, AlbumsSorting sorting = AlbumsSorting.Newest, int currentPage = 1, int albumsPerPage = 1)
        {
            var albums = repository
                .AllReadonly<Album>()
                .Where(a => a.IsActive);

            if (genre != null)
            {
                albums = albums.Where(a => a.Genre.Name == genre);
            }

            if (searchTerm != null)
            {
                searchTerm = searchTerm.ToUpper();
                albums = albums.Where(a => a.Artist.ToUpper().Contains(searchTerm) ||
                                      a.Title.ToUpper().Contains(searchTerm));
                                      
            }

            albums = sorting switch
            {
                AlbumsSorting.Oldest => albums.OrderBy(a => a.Id),
                AlbumsSorting.ReleaseYearAscending => albums.OrderBy(a => a.Year),
                AlbumsSorting.ReleaseYearDescending => albums.OrderByDescending(a => a.Year),
                _ => albums.OrderByDescending(a => a.Id)
            };

            var result = new AllAlbumsModel();

            result.Albums = albums
                .Skip((currentPage - 1) * albumsPerPage)
                .Take(albumsPerPage)
                .Select(a => new AlbumModel()
                {
                    Id = a.Id,
                    Artist = a.Artist,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl,
                    Genre = a.Genre,
                    Year = a.Year
                });

            result.TotalAlbumsCount = await albums.CountAsync();

            return result;
        }

        public async Task<IEnumerable<AlbumModel>> GetAllUserAlbums(string userId)
        {
            return await repository
                .AllReadonly<Album>()
                .Where(a => a.UserId == userId && a.IsActive)
                .Select(a=> new AlbumModel() 
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    Genre = a.Genre,
                    ImageUrl = a.ImageUrl,
                    Year = a.Year
                })
                .ToListAsync();
        }

        public async Task<ICollection<Comment>> GetComments(int albumId)
        {
            return await repository
                .AllReadonly<Comment>()
                .Where(c => c.AlbumId == albumId)
                .Include(c=> c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<AlbumGenreModel>> GetGenreModels()
        {
            var genres = await GetGenres();
            var genreModels = genres
                .Select(g => new AlbumGenreModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList();

            return genreModels;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            var genres = await repository
                .AllReadonly<Genre>()
                .ToListAsync();

            return genres;
        }

        public async Task<IEnumerable<HomepageAlbumModel>> GetLastThreeAlbums()
        {
            var albums = await repository
                .AllReadonly<Album>()
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.Id)
                .Take(3)
                .Select(a=> new HomepageAlbumModel() 
                {
                    Id = a.Id,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();

            return albums;
        }

        public Task<bool> IsAlbumAddedByUser()
        {
            throw new NotImplementedException();
        }
    }
}
