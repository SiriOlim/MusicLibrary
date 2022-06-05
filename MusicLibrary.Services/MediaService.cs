using MusicLibrary.Domain;
using MusicLibrary.ServiceInterfaces;
using MusicLibrary.Services.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaServiceHandler _mediaServiceHandler;

        public MediaService(IMediaServiceHandler mediaServiceHandler)
        {
            _mediaServiceHandler = mediaServiceHandler;
        }
        public async Task<List<Media>> Get()
        {
            return await _mediaServiceHandler.HandleGet();
        }
    }
}
