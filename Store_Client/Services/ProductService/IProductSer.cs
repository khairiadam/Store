using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
