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
    internal class MusicService
    {
        public Music GetById(int Id)
        {
            Music music;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                music = appDbContext.Musics.Include(m=>m.Categories).FirstOrDefault(i => i.Id == Id);
                if (music == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return music;
        }
        public void CreateMusic(string name,int duration, int categoryid)
        {
            Music music = new Music()
            {
                Name = name,
                Duration=duration,
                CategoryId = categoryid
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Musics.Add(music);
                dbcontext.SaveChanges();
                Console.WriteLine("Music Added");
            }
        }
        public void Delete(int id)
        {
            Music music;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                music = appDbContext.Musics.FirstOrDefault(s => s.Id == id);
                if (!(music == null))
                {
                    appDbContext.Musics.Remove(music);
                    appDbContext.SaveChanges();
                    Console.WriteLine(music.Name + " adli music ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli music yoxdu.");
                }
            }
        }
        public List<Music> GetAll()
        {
            List<Music> musics;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                musics = dbcontext.Musics.Include(m=>m.Categories).ToList();
            }
            return musics;
        }
        public void Update(Music music)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (music != null)
                {
                    context.Musics.Update(music);
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
