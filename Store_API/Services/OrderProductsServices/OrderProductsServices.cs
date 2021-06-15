using System.Collections.Generic;
using System.Threading.Tasks;
using Store_API.Data;
using Store_Shared.Models;

namespace Store_API.Services.OrderProductsServices
{
    public class OrderProductsServices : IOrderProductsService
    {
        private readonly AppDbContext _db;

        public OrderProductsServices(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<OrderProducts>> GetCartItems(List<CartItem> cartItems)
        {
            var orderProducts = new List<OrderProducts>();
            if (cartItems.Count < 0) return null;

            var Order = new Order();


            cartItems.ForEach(i =>
            {
                var orderProduct = new OrderProducts();
                orderProduct.OrderId = Order.Id;
                orderProduct.ProductId = i.Product.Product.Id;
                orderProduct.Quantity = i.Quantity;
                
            });

            return orderProducts;
        }
    }
}