using MusicLibrary.DataInterfaces;
using MusicLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;

namespace MusicLibrary.Data
{
    public class MediaRepository : IMediaRepository
    {
        public async Task<List<Media>> Get()
        {
            try
            {
                var parent = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
                string filePath = Path.Combine(parent, "SampleMediaStorage.json");
                var stringData = File.ReadAllText(filePath);

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
