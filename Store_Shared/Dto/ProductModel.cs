using System;
using System.Collections.Generic;
using Store_Shared.Models;

namespace Store_Shared.Dto
{
   public class ProductModel
    {
        public Product Product { get; set; }
        public List<Images> ProductImages { get; set; }
    

    }
}
