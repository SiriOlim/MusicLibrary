using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Domain
{
    public class Media
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public List<Song>? Songs { get; set; }
    }
}
