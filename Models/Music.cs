using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Models
{
    internal class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int CategoryId { set; get; }
        public Category Categories { get; set; }
        public ICollection<MusicArtist> MusicArtists { get; set; }
        public ICollection<PlaylistMusic> PlaylistsMusics{ get; set; }
        
    }
}
