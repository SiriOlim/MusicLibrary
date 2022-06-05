using MusicLibrary.Project.Resources;

namespace MusicLibrary.Project.Handlers.Interfaces
{
    public interface IMediaHandler
    {
        Task<ApiResponseResource> HandleGet();
        Task<ApiResponseResource> HandlePost(UpsertMediaRequestResource request);
    }
}
