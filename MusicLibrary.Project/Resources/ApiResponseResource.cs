namespace MusicLibrary.Project.Resources
{
    public class ApiResponseResource
    {
        public bool Success { get; set; }
        public List<MediaResource>? MediaResources { get; set; }
        public string? Message {get;set;}
    }
}
