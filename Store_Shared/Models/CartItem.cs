using Store_Shared.Dto;

namespace Store_Shared.Models
{
    public class CartItem
    {
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }
    }
}