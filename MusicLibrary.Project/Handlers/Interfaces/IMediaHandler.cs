using MusicLibrary.Project.Resources;

namespace MusicLibrary.Project.Handlers.Interfaces
{
    public interface IMediaHandler
    {
        Task<ApiResponseResource> HandleGet();
    }
}
