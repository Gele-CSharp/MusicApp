using MusicApp.Core.Models.Album;
using System.Text.RegularExpressions;

namespace MusicApp.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IAlbumModel album)
        => album.Title.Replace(" ", "-") + "-" + GetArtist(album.Artist);

        private static string GetArtist(string artist)
        {
            artist = string.Join("-", artist.Split(" ").Take(3));
            return Regex.Replace(artist, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
