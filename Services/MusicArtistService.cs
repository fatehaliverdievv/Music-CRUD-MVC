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
    internal class MusicArtistService
    {
        public MusicArtist GetById(int Id)
        {
            MusicArtist musicArtist;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                musicArtist = appDbContext.MusicArtists.Include(m => m.Musics).Include(m => m.Artists).FirstOrDefault(i => i.Id == Id);
                if (musicArtist == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return musicArtist;
        }
        public void CreateArtistMusic(int musicid, int artistid)
        {
            MusicArtist artistMusic = new MusicArtist()
            {
                ArtistId = artistid,
                MusicId = musicid
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.MusicArtists.Add(artistMusic);
                dbcontext.SaveChanges();
                Console.WriteLine("Song Added");
            }
        }
        public void Delete(int id)
        {
            MusicArtist musicArtist;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                musicArtist = appDbContext.MusicArtists.Include(m => m.Musics).Include(m => m.Artists).FirstOrDefault(s => s.Id == id);
                if (!(musicArtist == null))
                {
                    appDbContext.MusicArtists.Remove(musicArtist);
                    appDbContext.SaveChanges();
                    Console.WriteLine(musicArtist.Musics.Name + " adli song ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli song yoxdu.");
                }
            }
        }
        public List<MusicArtist> GetAll()
        {
            List<MusicArtist> musicArtists;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                musicArtists = dbcontext.MusicArtists.Include(m => m.Musics).Include(m => m.Artists).ToList();
            }
            return musicArtists;
        }
        public void Update(MusicArtist musicArtist)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (musicArtist != null)
                {
                    context.MusicArtists.Update(musicArtist);
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
