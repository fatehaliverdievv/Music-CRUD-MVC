using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Models
{
    internal class MusicArtist
    {
        public int Id { get; set; }
        public int MusicId { get; set; }
        public int ArtistId { get; set; }   
        public Artist Artists { get; set; }
        public Music Musics { get; set; }
    }
}
