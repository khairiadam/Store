using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Store_Shared.Dto;
using Store_Shared.Models;

namespace Store_API.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel> Get(string Id);
        Task<IEnumerable<ProductModel>> GetByCategory(string categoryId);
        Task<Product> Post(Product model, List<IFormFile> image);
        Task Delete(string Id);
        Task Update(Product model);
    }
}