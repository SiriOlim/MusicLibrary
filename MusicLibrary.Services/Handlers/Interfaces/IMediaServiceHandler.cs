using MusicLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Services.Handlers.Interfaces
{
    public interface IMediaServiceHandler
    {
        Task<List<Media>> HandleGet();
        Task<Media> HandleUpsert(Media media);
    }
}
