using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Store_Shared.Models;

namespace Store_API.Services.OrderProductsServices
{
    public interface IOrderProductsService
    {
        Task<List<OrderProducts>> GetCartItems(List<CartItem> cartItems);
    }
}