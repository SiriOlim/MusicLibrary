namespace MusicLibrary.Project.Resources
{
    public class ApiResponseResource
    {
        public List<MediaResource>? MediaResources { get; set; }
        public string? ErrorMessage {get;set;}
        public Exception? Exception {get;set;}
    }
}
