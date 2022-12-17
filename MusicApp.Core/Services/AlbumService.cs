using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
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
        private readonly ICommentService commentService;
        private readonly ILogger<AlbumService> logger;
        private readonly UserManager<User> userManager;

        public AlbumService(IRepository _repository,
                            ILogger<AlbumService> _logger,
                            ICommentService _commentService,
                            UserManager<User> _userManager)
        {
            repository = _repository;
            logger = _logger;
            commentService = _commentService;
            userManager = _userManager;
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

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Delete), ex);
                throw new ApplicationException("Database failed to save info.", ex);
            }

            return album.Id;
        }

        public async Task Delete(int albumId, string userId)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);
            var user = await repository.GetByIdAsync<User>(userId);

            if ((await IsAlbumAddedByUser(albumId, userId)) || (await userManager.IsInRoleAsync(user, "Administrator")))
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
            var user = await repository.GetByIdAsync<User>(userId);
            var album = await repository.GetByIdAsync<Album>(albumId);
            album.Title = model.Title;
            album.Artist = model.Artist;
            album.Description = model.Description;
            album.ImageUrl = model.ImageUrl;
            album.Year = model.Year;
            album.GenreId = model.GenreId;

            if ((await IsAlbumAddedByUser(albumId, userId)) || (await userManager.IsInRoleAsync(user, "Administrator")))
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

            var comments = await commentService.GetComments(albumId);

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

        public async Task<AlbumDetailsModel> AdminGetAlbumDetails(int albumId, bool isActive)
        {
            var album = await repository
                .AllReadonly<Album>()
                .Where(a=> isActive ? a.IsActive : a.IsActive == false)
                .Where(a => a.Id == albumId)
                .Include(a => a.User)
                .Include(a => a.Genre)
                .FirstAsync();

            var comments = await commentService.GetComments(albumId);

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
                IsActive = album.IsActive,
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

        public async Task<AddAlbumModel> AdminGetAlbumDetailsToEdit(int albumId)
        {
            var album = await repository
                .AllReadonly<Album>()
                .Where(a=> a.Id == albumId)
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
                GenreId = album.GenreId,
                IsActive = album.IsActive
            };
        }

        public async Task<Album> GetAlbum(int albumId)
        {
            return await repository.GetByIdAsync<Album>(albumId);
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

        public async Task<AdminAreaAllAlbumsModel> AdminGetAllAlbums(string? genre = null, string? searchTerm = null, AlbumsSorting sorting = AlbumsSorting.Newest, AlbumState state = AlbumState.Active)
        {
            var albums = repository
                .AllReadonly<Album>()
                .Where(a => state == AlbumState.Active ? a.IsActive : a.IsActive == false);

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

            var result = new AdminAreaAllAlbumsModel();

            result.Albums = albums
                .Select(a => new AdminAreaAlbumModel()
                {
                    Id = a.Id,
                    Artist = a.Artist,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl,
                    Genre = a.Genre,
                    Year = a.Year,
                    IsActive = a.IsActive
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

        public async Task Restore(int albumId, string userId)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);
            var user = await repository.GetByIdAsync<User>(userId);

            album.IsActive = true;

            if ((await userManager.IsInRoleAsync(user, "Administrator")))
            {
                try
                {
                    await repository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(Restore), ex);
                    throw new ApplicationException("Database failed to save info.", ex);
                }
            }
        }
    }
}
