using Microsoft.EntityFrameworkCore;
using spotifycrud.DAL;
using spotifycrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Services
{
    internal class PlaylistMusicService
    {
        public PlaylistMusic GetById(int Id)
        {
            PlaylistMusic playlistMusic;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                playlistMusic = appDbContext.PlaylistMusics.Include(m => m.Musics).Include(m=>m.Playlists).FirstOrDefault(i => i.Id == Id);
                if (playlistMusic == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return playlistMusic;
        }
        public void CreatePlaylistMusic(int musicid, int playlistid)
        {
            PlaylistMusic playlistMusic = new PlaylistMusic()
            {
                PlaylistId = playlistid,
                MusicId = musicid
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.PlaylistMusics.Add(playlistMusic);
                dbcontext.SaveChanges();
                Console.WriteLine("PLaylistMusic Added");
            }
        }
        public void Delete(int id)
        {
            PlaylistMusic playlistMusic;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                playlistMusic = appDbContext.PlaylistMusics.Include(m=>m.Musics).Include(m=>m.Playlists).FirstOrDefault(s => s.Id == id);
                if (!(playlistMusic == null))
                {
                    appDbContext.PlaylistMusics.Remove(playlistMusic);
                    appDbContext.SaveChanges();
                    Console.WriteLine(playlistMusic.Playlists.Name + " adli playlistmusic ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli playlistmusic yoxdu.");
                }
            }
        }
        public List<PlaylistMusic> GetAll()
        {
            List<PlaylistMusic> playlistMusics;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                playlistMusics = dbcontext.PlaylistMusics.Include(m => m.Musics).Include(m=>m.Playlists).ToList();
            }
            return playlistMusics;
        }
        public void Update(PlaylistMusic playlistMusic)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (playlistMusic != null)
                {
                    context.PlaylistMusics.Update(playlistMusic);
                    context.SaveChanges();
                    Console.WriteLine("Ugurla deyishildi");
                }
                else
                {
                    Console.WriteLine("Deyishmek mumkun olmadi");
                }
            }
        }

    }
}
