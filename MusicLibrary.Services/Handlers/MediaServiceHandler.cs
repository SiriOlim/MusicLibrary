using MusicLibrary.DataInterfaces;
using MusicLibrary.Domain;
using MusicLibrary.Services.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Services.Handlers
{
    public class MediaServiceHandler : IMediaServiceHandler
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaServiceHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }
        public async Task<List<Media>> HandleGet()
        {
            return await _mediaRepository.Get();
        }

        public async Task<Media> HandleUpsert(Media media)
        {
            return await _mediaRepository.Upsert(media);
        }
    }
}
