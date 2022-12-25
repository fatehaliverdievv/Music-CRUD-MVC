using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Models
{
    internal class PlaylistMusic
    {
        public int Id { get; set; }
        public int MusicId { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlists { get; set; }
        public Music Musics { get; set; }
    }
}
