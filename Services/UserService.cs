using spotifycrud.DAL;
using spotifycrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Services
{
    internal class UserService
    {
        public User GetById(int Id)
        {
            User user;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                user = appDbContext.Users.FirstOrDefault(i => i.Id == Id);
                if (user == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return user;
        }
        public void CreateUser(string name,string surname,string username,string password,string gender, int roleid)
        {
            User user = new User()
            {
                Name = name,
                Surname = surname,
                Username = username,
                Gender = gender,
                RoleId = roleid 
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                Console.WriteLine("User Added");
            }
        }
        public void Delete(int id)
        {
            User user;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                user = appDbContext.Users.FirstOrDefault(s => s.Id == id);
                if (!(user == null))
                {
                    appDbContext.Users.Remove(user);
                    appDbContext.SaveChanges();
                    Console.WriteLine(user.Name + " adli user ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli user yoxdu.");
                }
            }
        }
        public List<User> GetAll()
        {
            List<User> Users;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                Users = dbcontext.Users.ToList();
            }
            return Users;
        }
        public void Update(User user)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (user != null)
                {
                    context.Users.Update(user);
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
