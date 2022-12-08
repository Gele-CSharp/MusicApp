namespace MusicApp.Infrastructure.Data;

public static class DataConstants
{
    public static class Album
    {
        public const int AlbumTitleMinLength = 1;
        public const int AlbumTitleMaxLength = 50;

        public const int ArtistNameMinLength = 1;
        public const int ArtistNameMaxLength = 50;

        public const int DescriptionMinLength = 20;
        public const int DescriptionMaxLength = 500;

        public const int ReleaseYearMinValue = 1948;
        public const int ReleaseYearMaxValue = 2023;
    }

    public static class Comment
    {
        public const int AuthorNameMinLength = 2;
        public const int AuthorNameMaxLength = 50;

        public const int ContentMinLength = 5;
        public const int ContentMaxLength = 50;
    }

    public static class User
    {
        public const int UsernameMinLength = 2;
        public const int UsernameMaxLength = 50;

        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 50;

        public const int UserLastNameMinLength = 2;
        public const int UserLastNameMaxLength = 50;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;
    }

    public static class Event
    {
        public const int ArtistNameMinLength = 1;
        public const int ArtistNameMaxLength = 50;

        public const int LocationNameMinLength = 5;
        public const int LocationNameMaxLength = 50;
    }
}
