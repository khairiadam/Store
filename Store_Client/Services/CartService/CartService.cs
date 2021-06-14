using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NToastNotify;
using Store_Client.Services.LocalStorageService;
using Store_Client.Services.ProductService;
using Store_Shared.Models;

namespace Store_Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IProductSer _productService;
        private readonly IToastNotification _toastService;

        public CartService(
            ILocalStorageService localStorage,
            IToastNotification toastService,
            IProductSer productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }

        public event Action OnChange;


        public async Task AddToCart(CartItem item)
        {
            var cart = await _localStorage.GetItem<List<CartItem>>("cart");
            if (cart == null) cart = new List<CartItem>();

            var sameItem = cart
                .Find(x => x.Product.Product.Id == item.Product.Product.Id &&
                           x.Product.Product.ProductCategoryId == item.Product.Product.ProductCategoryId);
            if (sameItem == null)
                cart.Add(item);
            else
                sameItem.Quantity += item.Quantity;

            await _localStorage.SetItem("cart", cart);

            var product = _productService.Get(item.Product.Product.Id);
            _toastService.AddSuccessToastMessage(product.Product.Name + ", Added to Cart.");

            OnChange.Invoke();
        }


        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItem<List<CartItem>>("cart");
            if (cart == null) return new List<CartItem>();
            return cart;
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItem<List<CartItem>>("cart");
            if (cart == null) return;

            var cartItem = cart.Find(x =>
                x.Product.Product.Id == item.Product.Product.Id &&
                x.Product.Product.ProductCategoryId == item.Product.Product.ProductCategoryId);
            cart.Remove(cartItem);

            await _localStorage.SetItem("cart", cart);
            OnChange.Invoke();
        }

        public async Task EmptyCart()
        {
            await _localStorage.RemoveItem("cart");
            OnChange.Invoke();
        }

        //TODO: ADD This
        private async Task AddProductToCard(string id)
        {
            var cartItem = new CartItem {Quantity = 1};
            var product = _productService.Get(id);

            cartItem.Product = product;

            await AddToCart(cartItem);
        }
    }
}