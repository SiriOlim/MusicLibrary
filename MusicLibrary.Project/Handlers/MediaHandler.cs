using MusicLibrary.Project.Builders.Interfaces;
using MusicLibrary.Project.Handlers.Interfaces;
using MusicLibrary.Project.Resources;
using MusicLibrary.ServiceInterfaces;

namespace MusicLibrary.Project.Handlers
{
    public class MediaHandler : IMediaHandler
    {
        private readonly IMediaResourceBuilder _mediaResourceBuilder;
        private readonly IMediaService _mediaService;

        public MediaHandler(IMediaResourceBuilder mediaResourceBuilder, IMediaService mediaService)
        {
            _mediaResourceBuilder = mediaResourceBuilder;
            _mediaService = mediaService;
        }
        public async Task<ApiResponseResource> HandleGet()
        {
            try
            {
                var res = await _mediaService.Get();

                return new()
                {
                    ErrorMessage = "",
                    MediaResources = res.Select(_mediaResourceBuilder.Build).ToList(),
                    Exception = null
                };
            }
            catch(Exception ex)
            {
                // Log Error
                return new ApiResponseResource()
                {
                    ErrorMessage = ex.Message,
                    Exception = ex,
                    MediaResources = new()
                };
            }
        }
    }
}
