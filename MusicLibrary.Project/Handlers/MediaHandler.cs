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
                    Success = true,
                    Message = "",
                    MediaResources = res.Select(_mediaResourceBuilder.Build).ToList(),
                };
            }
            catch(Exception ex)
            {
                // Log Error
                return new ApiResponseResource()
                {
                    Success = false,
                    Message = ex.Message,
                    MediaResources = new()
                };
            }
        }

        public async Task<ApiResponseResource> HandlePost(UpsertMediaRequestResource request)
        {
            if(request.Media is null)
            {
                return new ApiResponseResource()
                {
                    Success = false,
                    Message = "Invalid Request. Media can not be null.",
                    MediaResources = new()
                };
            }

            try
            {
                var media = _mediaResourceBuilder.Build(request.Media);

                var res = await _mediaService.Upsert(media);

                var resources = new List<MediaResource>();
                resources.Add(_mediaResourceBuilder.Build(res));
                return BuildApiResponse(true, "Upsert successful.", resources);
            }
            catch(Exception ex)
            {
                return BuildApiResponse(false, ex.Message, new());

            }
        }

        private ApiResponseResource BuildApiResponse(bool success, string message, List<MediaResource> mediaResources)
        {
            return new ApiResponseResource()
            {
                Success = success,
                MediaResources = mediaResources,
                Message = message
            };
        }
    }
}
