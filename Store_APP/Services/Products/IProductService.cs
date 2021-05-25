using Microsoft.AspNetCore.Http;
using Store_Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store_Shared.Dto;


namespace Store_APP.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel> Get(string Id);
        Task<IEnumerable<ProductModel>> GetByCategory(string CategoryId);
        Task<Product> Post(Product model, List<IFormFile> image);
        Task Delete(string Id);
        Task Update(Product model);

    }
}