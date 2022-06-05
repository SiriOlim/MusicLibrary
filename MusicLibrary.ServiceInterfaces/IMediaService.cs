using MusicLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.ServiceInterfaces
{
    public interface IMediaService
    {
        Task<List<Media>> Get();
        Task<Media> Upsert(Media media);
    }
}
