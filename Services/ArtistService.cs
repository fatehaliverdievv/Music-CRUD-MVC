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
    internal class ArtistService
    {
        public Artist GetById(int Id)
        {
            Artist artist;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                artist = appDbContext.Artists.FirstOrDefault(i => i.Id == Id);
                if (artist == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return artist;
        }
        public void CreateArtist(string StageName, string name, string surname, string gender, DateTime birthday)
        {
            Artist artist = new Artist()
            {
                StageName = StageName,
                Name = name,
                Surname = surname,
                Gender=gender,
                Birthday=birthday
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Artists.Add(artist);
                dbcontext.SaveChanges();
                Console.WriteLine("Artist Added");
            }
        }
        public void Delete(int id)
        {
            Artist artist;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                artist = appDbContext.Artists.FirstOrDefault(s => s.Id == id);
                if (!(artist == null))
                {
                    appDbContext.Artists.Remove(artist);
                    appDbContext.SaveChanges();
                    Console.WriteLine(artist.StageName + " adli artist ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli artist yoxdu.");
                }
            }
        }
        public List<Artist> GetAll()
        {
            List<Artist> artists;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                artists = dbcontext.Artists.ToList();
            }
            return artists;
        }
        public void Update(Artist artists)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (artists != null)
                {
                    context.Artists.Update(artists);
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
