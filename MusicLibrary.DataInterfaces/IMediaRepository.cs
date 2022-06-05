using MusicLibrary.Domain;

namespace MusicLibrary.DataInterfaces
{
    public interface IMediaRepository
    {
        Task<List<Media>> Get();
    }
}
