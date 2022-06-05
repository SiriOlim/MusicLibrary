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

        public Media Build(MediaResource resource)
        {
            var media = new Media();
            media.Id = resource.Id;
            media.Title = resource.Title;
            media.Songs = resource?.Songs?.Select(Build).ToList() ?? new();
            return media;
        }

        public Song Build(SongResource resource)
        {
            var song = new Song();
            song.Id = resource.Id;
            song.Title = resource.Title;
            song.Artist = resource.Artist;
            song.Duration = resource.Duration;
            return song;
        }
    }
}
