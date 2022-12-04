﻿namespace MusicApp.Infrastructure.Data
{
    public static class DataConstants
    {
        public static class Album
        {
            public const int AlbumTitleMinLength = 1;
            public const int AlbumTitleMaxLength = 50;

            public const int ArtistNameMinLength = 1;
            public const int ArtistNameMaxLength = 50;
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
            public const int UserFirstNameMinLength = 2;
            public const int UserFirstNameMaxLength = 50;

            public const int UserLastNameMinLength = 2;
            public const int UserLastNameMaxLength = 50;
        }

        public static class Event
        {
            public const int ArtistNameMinLength = 1;
            public const int ArtistNameMaxLength = 50;

            public const int LocationNameMinLength = 5;
            public const int LocationNameMaxLength = 50;
        }
    }
}
