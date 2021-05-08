using Store_Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Store_APP.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(string Id);
        Task<Product> Post(Product model, List<IFormFile> image);
        Task Delete(string Id);
        Task Update(Product model);

    }
}