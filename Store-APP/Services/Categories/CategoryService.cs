using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store_API.Data;
using Store_Shared.Models;

namespace Store_APP.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }
        //TODO Each one of the group should implement one Method
        public async Task Delete(string id)
        {
            var delCategory = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(delCategory);
            await _db.SaveChangesAsync();
        }

        public async Task<Category> Get(string id)
        {
            var find = await _db.Categories.FindAsync(id);
            return find;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> Post(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task Put(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

    }
}