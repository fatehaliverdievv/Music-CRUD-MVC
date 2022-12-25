using spotifycrud.DAL;
using spotifycrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Services
{
    internal class RoleService
    {
        public Role GetById(int Id)
        {
            Role role;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                role = appDbContext.Roles.FirstOrDefault(i => i.Id == Id);
                if (role == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return role;
        }
        public void CreateRole(string name)
        {
            Role roles = new Role()
            {
                Type = name,
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Roles.Add(roles);
                dbcontext.SaveChanges();
                Console.WriteLine("Role Added");
            }
        }
        public void Delete(int id)
        {
            Role role;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                role = appDbContext.Roles.FirstOrDefault(s => s.Id == id);
                if (!(role == null))
                {
                    appDbContext.Roles.Remove(role);
                    appDbContext.SaveChanges();
                    Console.WriteLine(role.Type + " adli role ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli role yoxdu.");
                }
            }
        }
        public List<Role> GetAll()
        {
            List<Role> roles;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                roles = dbcontext.Roles.ToList();
            }
            return roles;
        }
        public void Update(Role role)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (role != null)
                {
                    context.Roles.Update(role);
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
