using System.Collections.Generic;
using System.Threading.Tasks;
using Store_Shared.Models;

namespace Store_API.Services.Orders
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> Get(string id);
        Task<bool> Post(Order order);
        Task<bool> Put(Order order);
        Task<bool> Delete(string id);
        Task<Order> GetOrderByUserId(string userId);
        Task ConfirmOrder(Order order);
    }
}