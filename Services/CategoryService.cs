using spotifycrud.DAL;
using spotifycrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifycrud.Services
{
    internal class CategoryService
    {
        public Category GetById(int Id)
        {
            Category category;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                category = appDbContext.Categories.FirstOrDefault(i => i.Id == Id);
                if (category == null)
                {
                    Console.WriteLine("Bele Id yoxdu");
                }
            }
            return category;
        }
        public void CreateCategory( string name)
        {
            Category categories = new Category()
            {
                Name = name,
            };
            using (AppDbContext dbcontext = new AppDbContext())
            {
                dbcontext.Categories.Add(categories);
                dbcontext.SaveChanges();
                Console.WriteLine("Category Added");
            }
        }
        public void Delete(int id)
        {
            Category category;
            using (AppDbContext appDbContext = new AppDbContext())
            {
                category = appDbContext.Categories.FirstOrDefault(s => s.Id == id);
                if (!(category == null))
                {
                    appDbContext.Categories.Remove(category);
                    appDbContext.SaveChanges();
                    Console.WriteLine(category.Name + " adli category ugurla silindi");
                }
                else
                {
                    Console.WriteLine("Bele idli category yoxdu.");
                }
            }
        }
        public List<Category> GetAll()
        {
            List<Category> categories;
            using (AppDbContext dbcontext = new AppDbContext())
            {
                categories = dbcontext.Categories.ToList();
            }
            return categories;
        }
        public void Update(Category category)
        {
            using (AppDbContext context = new AppDbContext())
            {
                if (category != null)
                {
                    context.Categories.Update(category);
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
