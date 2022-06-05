using MusicLibrary.Domain;
using MusicLibrary.Project.Builders.Interfaces;
using MusicLibrary.Project.Resources;

namespace MusicLibrary.Project.Builders
{
    public class MediaResourceBuilder : IMediaResourceBuilder
    {
        public MediaResource Build(Media media)
        {
            var resource = new MediaResource();
            resource.Id = media.Id;
            resource.Title = media.Title;
            resource.Songs = media?.Songs?.Select(Build).ToList() ?? new();
            return resource;
        }

        public SongResource Build(Song song)
        {
            var resource = new SongResource();
            resource.Id = song.Id;
            resource.Title = song.Title;
            resource.Artist = song.Artist;
            resource.Duration = song.Duration;
            return resource;
        }
    }
}
