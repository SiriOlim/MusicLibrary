using MusicLibrary.Domain;
using MusicLibrary.Project.Resources;

namespace MusicLibrary.Project.Builders.Interfaces
{
    public interface IMediaResourceBuilder
    {
        MediaResource Build(Media media);
        SongResource Build(Song song);
    }
}
