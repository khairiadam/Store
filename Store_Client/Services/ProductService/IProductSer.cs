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
        IEnumerable<Product> Get();
        Product Get(string id);

    }
}
