using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Client.Services.ProductService
{
    public interface IProductSer
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(string id);

    }
}
