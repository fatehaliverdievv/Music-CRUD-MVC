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
    internal class PlaylistService
    {
        public Playlist GetById(int Id)
        {
            Playlist playlist;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                playlist = appDbContext.Playlists.Include(m => m.User).FirstOrDefault(i => i.Id == Id);
                if (playlist == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return playlist;
        }
        public void CreatePlaylist(string name, int userid)
        {
            Playlist playlist = new Playlist()
            {
                Name=name,
                UserId=userid
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Playlists.Add(playlist);
                dbcontext.SaveChanges();
                Console.WriteLine("Playlist Added");
            }
        }
        public void Delete(int id)
        {
            Playlist playlist;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                playlist = appDbContext.Playlists.FirstOrDefault(s => s.Id == id);
                if (!(playlist == null))
                {
                    appDbContext.Playlists.Remove(playlist);
                    appDbContext.SaveChanges();
                    Console.WriteLine(playlist.Name + " adli playlist ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli playlist yoxdu.");
                }
            }
        }
        public List<Playlist> GetAll()
        {
            List<Playlist> playlists;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                playlists = dbcontext.Playlists.Include(m=>m.User).ToList();
            }
            return playlists;
        }
        public void Update(Playlist playlist)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (playlist != null)
                {
                    context.Playlists.Update(playlist);
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
