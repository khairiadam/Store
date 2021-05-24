using System.Collections.Generic;
using Store_Shared.Models;

namespace Store_Shared.Dto
{
   public class ProductModel
    {
        public List<Images> ProductImages { get; set; }
        public Product Product { get; set; }
    }
}
