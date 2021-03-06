using MusicLibrary.Domain;

namespace MusicLibrary.DataInterfaces
{
    public interface IMediaRepository
    {
        Task<List<Media>> Get();
        Task<Media> Upsert(Media media);
    }
}
