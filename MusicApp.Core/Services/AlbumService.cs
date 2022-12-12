using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Core.Models.Comments;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository repository;
        private readonly ILogger<AlbumService> logger;

        public AlbumService(IRepository _repository,
                            ILogger<AlbumService> _logger)
        {
            repository = _repository;
            logger = _logger;
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


        public async Task Delete(int albumId, string userId)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);

            if ((await IsAlbumAddedByUser(albumId, userId)))
            {
                album.IsActive = false;

                try
                {
                    await repository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(Delete), ex);
                    throw new ApplicationException("Database failed to save info.", ex);
                }
            }
        }

        public async Task Edit(int albumId, string userId, AddAlbumModel model)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);
            album.Title = model.Title;
            album.Artist = model.Artist;
            album.Description = model.Description;
            album.ImageUrl = model.ImageUrl;
            album.Year = model.Year;
            album.GenreId = model.GenreId;

            if ((await IsAlbumAddedByUser(albumId, userId)))
            {
                try
                {
                    await repository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(Edit), ex);
                    throw new ApplicationException("Database failed to save info.", ex);
                }
            }
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

        public async Task<AddAlbumModel> GetAlbumDetailsToEdit(int albumId)
        {
            var album = await repository
                .AllReadonly<Album>()
                .Where(a => a.IsActive && a.Id == albumId)
                .Include(a => a.User)
                .Include(a => a.Genre)
                .FirstAsync();

            return new AddAlbumModel()
            {
                Id = album.Id,
                Title = album.Title,
                Artist = album.Artist,
                ImageUrl = album.ImageUrl,
                Description = album.Description,
                Year = album.Year,
                GenreId = album.GenreId
            };
        }

        public async Task<IEnumerable<AlbumDetailsModel>> GetAlbumsDetails()
        {
            return await repository
                .AllReadonly<Album>()
                .Include(a=> a.User)
                .Include(a=> a.Genre)
                .Include(a=> a.Comments)
                .Where(a => a.IsActive)
                .Select(a=> new AlbumDetailsModel() 
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    Description = a.Description,
                    Year = a.Year,
                    GenreId = a.GenreId,
                    Genre = a.Genre,
                    UserId = a.UserId,
                    User = a.User,
                    ImageUrl = a.ImageUrl,
                    Likes = a.Likes,
                    Comments = new CommentModel()
                    {
                        AlbumId = a.Id,
                        Comments = a.Comments
                    }
                })
                .ToListAsync();
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

        public async Task<AllAlbumsModel> GetAllAlbums(string? genre = null, string? searchTerm = null, AlbumsSorting sorting = AlbumsSorting.Newest)
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
                    ImageUrl = a.ImageUrl,
                    Artist = a.Artist
                })
                .ToListAsync();

            return albums;
        }

        public async Task<bool> IsAlbumAddedByUser(int albumId, string userId)
        {
            var isAddedByUser = await repository
                .AllReadonly<Album>()
                .AnyAsync(a=> a.Id == albumId && a.UserId == userId);

            return isAddedByUser;
        }

        public async Task<bool> IsAlbumLikedByUser(int albumId, string userId)
        {
            var user = await repository
                .AllReadonly<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Likes)
                .FirstAsync();

            return user.Likes.Any(l=> l.AlbumId == albumId);
        }

        public async Task LikeAlbum(int albumId, string userId)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);
            var user = await repository.GetByIdAsync<User>(userId);

            album.Likes++;
            user.Likes.Add(new Like() { AlbumId = albumId });

            if ((await IsAlbumAddedByUser(albumId, userId)) == false && (await IsAlbumLikedByUser(albumId, userId)) == false)
            {
                try
                {
                    await repository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(LikeAlbum), ex);
                    throw new ApplicationException("Database failed to save info.", ex);
                }
            }
        }
    }
}
