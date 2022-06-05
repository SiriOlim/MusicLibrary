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
        public async Task<List<MediaResource>> HandleGet()
        {
            var res = await _mediaService.Get();

            return res.Select(_mediaResourceBuilder.Build).ToList();
        }
    }
}
