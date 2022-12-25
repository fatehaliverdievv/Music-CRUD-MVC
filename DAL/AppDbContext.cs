using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using spotifycrud.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
    namespace spotifycrud.DAL
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-9GSQT59\\SQLEXPRESS; database=SpotifyPhateh;integrated security=true;trusted_connection=true;Encrypt=false;");
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<MusicArtist> MusicArtists { get; set;}
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlaylistMusic> PlaylistMusics { get; set; }    
    }
}
