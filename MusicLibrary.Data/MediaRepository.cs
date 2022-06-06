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
        private readonly string _filePath;
        public MediaRepository()
        {
            _filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "SampleMediaStorage.json");
        }
        public async Task<List<Media>> Get()
        {
            try
            {
                var stringData = File.ReadAllText(_filePath);

                var data = JsonSerializer.Deserialize<List<Media>>(stringData);

                return data is null ? new() : data;
            }
            catch(Exception ex)
            {
                //log error
                throw;
            }
        }

        public async Task<Media> Upsert(Media media)
        {
            try
            {
                ProcessMedia(media);

                var stringData = File.ReadAllText(_filePath);
                var mediaList = JsonSerializer.Deserialize<List<Media>>(stringData);

                var isFound = mediaList?.FirstOrDefault(x => x.Id == media.Id);
                if (isFound != null)
                {
                    // Update
                    mediaList?.Remove(isFound);
                    mediaList?.Add(media);

                    var data = JsonSerializer.Serialize(mediaList);

                    await SaveFile(data);
                }
                else
                {
                    // Insert
                    mediaList?.Add(media);

                    var data = JsonSerializer.Serialize(mediaList);

                    await SaveFile(data);
                }
                return await Task.FromResult(media);
            }
            catch(Exception ex)
            {
                // log error
                throw;
            }
        }

        private async Task SaveFile(string data)
        {
            await File.WriteAllTextAsync(_filePath, data);
        }

        private bool IsOver60(Media media)
        {
            return media?.Songs?.Sum(x => x.Duration) > 60;
        }

        private void ProcessMedia(Media media)
        {
            if(!IsOver60(media))
            {
                return;
            }
            else
            {
                throw new Exception("Media exceeded limit.");
            }
        }
    }
}
