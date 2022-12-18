using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Core.Services;
using MusicApp.Data;
using MusicApp.Infrastructure.Common;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.UnitTests
{
    public class AlbumServiceTests
    {
        private IRepository repository;
        private ILogger<AlbumService> logger;
        private IAlbumService albumService;
        private ICommentService commentService;
        private MusicAppDbContext context;
        private UserManager<User> userManager;


        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<MusicAppDbContext>()
                .UseInMemoryDatabase("MusicAppDB")
                .Options;

            context = new MusicAppDbContext(contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task TestGetLastThreeAlbums()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"},
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"},
                new Album() { Id = 33, Artist = "Artist3", Title = "Title3", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"},
                new Album() { Id = 34, Artist = "Artist4", Title = "Title4", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"},
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);
            var albums = await albumService.GetLastThreeAlbums();

            Assert.That(3, Is.EqualTo(albums.Count()));
            Assert.That(albums.Any(a => a.Id == 31) == false);
        }

        [Test]
        public async Task TestAlbumEdit()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"}
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            await albumService.Edit(31, "0da97986-aee3-4b3f-97e4-466f510dd5d9", new AddAlbumModel()
            {
                Artist = "Edited Artist",
                Title = "Edited Title",
                Description = "",
                Year = 2022,
                ImageUrl = ""
            });

            var album = await repository.GetByIdAsync<Album>(31);
            Assert.That(album.Artist, Is.EqualTo("Edited Artist"));
            Assert.That(album.Title, Is.EqualTo("Edited Title"));
        }

        [Test]
        public async Task TestAlbumDelete()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"},
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9"},
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            await albumService.Delete(32, "0da97986-aee3-4b3f-97e4-466f510dd5d9");

            Assert.That((await repository.AllReadonly<Album>().CountAsync(a=> a.IsActive)), Is.EqualTo(1));
            Assert.That((await repository.AllReadonly<Album>().AnyAsync(a=> a.Id == 32 && a.IsActive)), Is.EqualTo(false));
        }

        [Test]
        public async Task TestAddAlbum()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var newAlbum = new AddAlbumModel() { Artist = "NewArtist", Title = "NewTitle", Description = "", Year = 2022, ImageUrl = "" };
            
            await albumService.AddAlbum(newAlbum, "0da97986-aee3-4b3f-97e4-466f510dd5d9");

            Assert.That((await repository.AllReadonly<Album>().CountAsync(a => a.IsActive)), Is.EqualTo(1));
            Assert.That((await repository.AllReadonly<Album>().AnyAsync(a => a.Artist == "NewArtist" 
                                                                          && a.Title == "NewTitle")), Is.EqualTo(true));
        }

        [Test]
        public async Task TestGetAlbumDetails()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="userId", GenreId = 0, Comments = new List<Comment>()},
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="userId", GenreId = 1, Comments = new List<Comment>()},
            });

            await repository.AddRangeAsync(new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Pop",  Albums = new HashSet<Album>() },
                new Genre() { Id = 2, Name = "Rock",  Albums = new HashSet<Album>() },
                new Genre() { Id = 3, Name = "Jazz",  Albums = new HashSet<Album>() },
            });

            await repository.AddRangeAsync(new List<User>()
            {
                new User() { Id = "userId", FirstName = "UserFirstNane", LastName = "UserLastNane",  Albums = new HashSet<Album>(), Likes = new HashSet<Like>() }
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var details = await albumService.GetAlbumDetails(31);

            Assert.That(details.Id, Is.EqualTo(31));
            Assert.That(details.Artist, Is.EqualTo("Artist1"));
            Assert.That(details.IsActive, Is.EqualTo(true));
        }

        [Test]
        public async Task GetAlbum()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>()},
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>()},
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var album = await albumService.GetAlbum(31);

            Assert.That(album.Id, Is.EqualTo(31));
            Assert.That(album.Artist, Is.EqualTo("Artist1"));
            Assert.That(album.IsActive, Is.EqualTo(true));
        }

        [Test]
        public async Task GetAllAlbums()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() } },
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() } },
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var albums = await albumService.GetAllAlbums(null, null, AlbumsSorting.Newest, 1, 2);

            Assert.That(albums.TotalAlbumsCount, Is.EqualTo(2));
            Assert.That(albums.Albums.Any(a=> a.Id == 31), Is.EqualTo(true));
            Assert.That(albums.Albums.Any(a=> a.Artist == "Artist2"), Is.EqualTo(true));
        }

        [Test]
        public async Task AdminGetAllAlbums()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = false },
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var albums = await albumService.AdminGetAllAlbums(null, null, AlbumsSorting.Newest, AlbumState.Deleted);

            Assert.That(albums.TotalAlbumsCount, Is.EqualTo(1));
            Assert.That(albums.Albums.Any(a => a.Id == 32), Is.EqualTo(true));
            Assert.That(albums.Albums.Any(a => a.Id == 31), Is.EqualTo(false));
        }

        [Test]
        public async Task GetAllUserAlbums()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 33, Artist = "Artist3", Title = "Title3", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd577", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 34, Artist = "Artist4", Title = "Title4", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = false },
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var albums = await albumService.GetAllUserAlbums("0da97986-aee3-4b3f-97e4-466f510dd5d9");

            Assert.That(albums.Count(), Is.EqualTo(2));
            Assert.That(albums.Any(a => a.Id == 32), Is.EqualTo(true));
            Assert.That(albums.Any(a => a.Id == 33), Is.EqualTo(false));
            Assert.That(albums.Any(a => a.Id == 34), Is.EqualTo(false));
        }

        [Test]
        public async Task GetGenres()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Pop",  Albums = new HashSet<Album>() }, 
                new Genre() { Id = 2, Name = "Rock",  Albums = new HashSet<Album>() }, 
                new Genre() { Id = 3, Name = "Jazz",  Albums = new HashSet<Album>() },
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var genres = await albumService.GetGenres();

            Assert.That(genres.Count(), Is.EqualTo(3));
            Assert.That(genres.Any(a => a.Id == 1), Is.EqualTo(true));
            Assert.That(genres.Any(a => a.Name == "Rock"), Is.EqualTo(true));
            Assert.That(genres.Any(a => a.Id == 4), Is.EqualTo(false));
        }

        [Test]
        public async Task TestIsAlbumAddedByUser()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 32, Artist = "Artist2", Title = "Title2", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 33, Artist = "Artist3", Title = "Title3", Description = "", Year = 2022, ImageUrl = "", UserId ="otherUser", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true },
                new Album() { Id = 34, Artist = "Artist4", Title = "Title4", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = false },
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            var isAlbumAddedByUser = await albumService.IsAlbumAddedByUser(31, "0da97986-aee3-4b3f-97e4-466f510dd5d9");
            Assert.That(isAlbumAddedByUser, Is.EqualTo(true));

            isAlbumAddedByUser = await albumService.IsAlbumAddedByUser(33, "0da97986-aee3-4b3f-97e4-466f510dd5d9");
            Assert.That(isAlbumAddedByUser, Is.EqualTo(false));
        }

        [Test]
        public async Task TestLikeAlbum()
        {
            var loggerMock = new Mock<ILogger<AlbumService>>();
            logger = loggerMock.Object;

            var commentServiceMock = new Mock<ICommentService>();
            commentService = commentServiceMock.Object;

            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new User()
                {
                    UserName = "test@email.com",
                    Id = "123"
                });

            var managerMock = new UserManager<User>(store.Object, null, null, null, null, null, null, null, null);

            var repository = new Repository(context);

            await repository.AddRangeAsync(new List<Album>()
            {
                new Album() { Id = 31, Artist = "Artist1", Title = "Title1", Description = "", Year = 2022, ImageUrl = "", UserId ="0da97986-aee3-4b3f-97e4-466f510dd5d9", Comments = new List<Comment>(), Genre = new Genre() {Id = 0, Name= "Pop", Albums = new HashSet<Album>() }, IsActive = true, Likes = 0 },
            });

            await repository.AddRangeAsync(new List<User>()
            {
                new User() { Id = "userId", FirstName = "UserFirstNane", LastName = "UserLastNane",  Albums = new HashSet<Album>(), Likes = new HashSet<Like>() }
            });

            await repository.SaveChangesAsync();

            albumService = new AlbumService(repository, logger, commentService, managerMock);

            await albumService.LikeAlbum(31, "userId");
            var album = await albumService.GetAlbum(31);

            Assert.That(album.Likes, Is.EqualTo(1));

            await albumService.LikeAlbum(31, "userId");

            Assert.That(album.Likes, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}