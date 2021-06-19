using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store_API.Data;
using Store_API.Services.Orders;
using Store_Shared.Models;

namespace Store_API.Services.OrderProductsServices
{
    public class OrderProductsService : IOrderProductsService
    {
        private readonly AppDbContext _db;

        public OrderProductsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<OrderProducts>> GetCartItems(List<CartItem> cartItems)
        {
            var orderProducts = new List<OrderProducts>();
            if (cartItems.Count < 0) return null;

            //TODO Change this with service OrderAdd
            var order = new Order();
            order.OrderStatus = Status.NotPaid;
            try
            {
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            // if (!await _order.Post(order)) return null;

            cartItems.ForEach(i =>
            {
                var orderProduct = new OrderProducts
                {
                    OrderId = order.Id,
                    ProductId = i.Product.Product.Id,
                    Quantity = i.Quantity
                };
                //TODO: Need Finish !!
            });

            try
            {
                await _db.AddAsync(orderProducts);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return orderProducts;
        }
    }
}