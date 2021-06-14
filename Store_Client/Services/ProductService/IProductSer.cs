using System.Collections.Generic;
using Store_Shared.Dto;

namespace Store_Client.Services.ProductService
{
    public interface IProductSer
    {
        IEnumerable<ProductModel> Get();
        IEnumerable<ProductModel> GetByCategory(string idCategory);
        ProductModel Get(string id);
    }
}