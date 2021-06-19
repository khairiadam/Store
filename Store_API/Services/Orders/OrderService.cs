using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store_API.Data;
using Store_Shared.Models;

namespace Store_API.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly HttpContext _context;

        public OrderService(AppDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            //_context = context;
            _userManager = userManager;
        }

        public async Task<bool> Delete(string id)
        {
            var supOrder = await _db.Orders.FindAsync(id);
            if (supOrder is null) return false;
            _db.Orders.Remove(supOrder);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Order> GetOrderByUserId(string userId)
        {
            var userOrders = _db.Orders
                .OrderByDescending(o => o.CreationDate)
                .Where(o => o.UserId == userId) as IEnumerable<Order>;
            return userOrders.FirstOrDefault(o => o.OrderStatus == Status.Pending);
        }

        public async Task ConfirmOrder(Order order)
        {
            order.OrderStatus = Status.Paid;
            try
            {
                _db.Update(order);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public async Task<Order> Get(string id)
        {
            var find = await _db.Orders.FindAsync(id);
            return find;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<bool> Post(Order order)
        {
            if (order == null) return false;
            try
            {
                //var user = await _userManager.GetUserAsync(_context.User);
                //order.UserId = user.Id;
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Put(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            if (result < 0) return false;
            return true;
        }
    }
}