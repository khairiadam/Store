﻿using NToastNotify;
using Store_Client.Services.LocalStorageService;
using Store_Client.Services.ProductService;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store_Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastNotification _toastService;
        private readonly IProductSer _productService;

        public event Action OnChange;

        public CartService(
            ILocalStorageService localStorage,
            IToastNotification toastService,
            IProductSer productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }



        public async Task AddToCart(CartItem item)
        {
            var cart = await _localStorage.GetItem<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart
                .Find(x => x.Product.Id == item.Product.Id && x.Product.ProductCategoryId == item.Product.ProductCategoryId);
            if (sameItem == null)
            {
                cart.Add(item);
            }
            else
            {
                sameItem.Quantity += item.Quantity;
            }

            await _localStorage.SetItem("cart", cart);

            var product = _productService.Get(item.Product.Id);
            _toastService.AddSuccessToastMessage(product.Name + ", Added to Cart.");

            OnChange.Invoke();
        }

        //TODO: ADD This

        private async Task AddProductToCard(string id)
        {
            CartItem cartItem = new CartItem { Quantity = 1 };
            var product = _productService.Get(id);


            cartItem.Product = product;
            //cartItem.ProductId = product.Id;
            await AddToCart(cartItem);

            //var productVariant = GetSelectedVariant();

            //cartItem.EditionId = productVariant.EditionId;
            //cartItem.EditionName = productVariant.Edition.Name;
            //cartItem.Image = product.Image;
            //cartItem.Price = productVariant.Price;
            //cartItem.ProductId = productVariant.ProductId;
            //cartItem.ProductTitle = product.Title;

            //await CartService.AddToCart(cartItem);
        }


        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItem<List<CartItem>>("cart");
            if (cart == null)
            {
                return new List<CartItem>();
            }
            return cart;
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItem<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.Product.Id == item.Product.Id && x.Product.ProductCategoryId == item.Product.ProductCategoryId);
            cart.Remove(cartItem);

            await _localStorage.SetItem("cart", cart);
            OnChange.Invoke();
        }

        public async Task EmptyCart()
        {
            await _localStorage.RemoveItem("cart");
            OnChange.Invoke();
        }
    }

}
