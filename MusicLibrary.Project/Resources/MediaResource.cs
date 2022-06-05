namespace MusicLibrary.Project.Resources
{
    public class MediaResource
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public List<SongResource>? Songs { get; set; }
    }
}
