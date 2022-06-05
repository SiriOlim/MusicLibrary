using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Project.Handlers.Interfaces;
using MusicLibrary.Project.Resources;
using System.Collections.Generic;

namespace MusicLibrary.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponseResource> Get([FromServices] IMediaHandler handler)
        {
            return await handler.HandleGet();
        }
    }
}
