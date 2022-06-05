using MusicLibrary.DataInterfaces;
using MusicLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MusicLibrary.Data
{
    public class MediaRepository : IMediaRepository
    {
        public async Task<List<Media>> Get()
        {
            try
            {
                string fileDir = @"~\SampleMediaStorage.json";
                var stringData = File.ReadAllText(fileDir);

                var data = JsonSerializer.Deserialize<List<Media>>(stringData);

                return data is null ? new() : data;
            }
            catch(Exception ex)
            {
                //log error
                throw;
            }
        }
    }
}
