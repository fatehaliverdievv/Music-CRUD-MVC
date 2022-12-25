using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Models
{
    internal class Playlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<PlaylistMusic> PlaylistMusics { get; set; }
    }
}
