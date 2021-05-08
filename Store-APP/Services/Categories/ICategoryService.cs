using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Store_Shared.Models;

namespace Store_API.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(string categoryId);
        Task<Category> Post(Category category, List<IFormFile> image);
        Task<Category> Put(Category category, List<IFormFile> image);
        Task Delete(string id);
    }
}
