using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store_API.Data;
using Store_Shared.Dto;
using Store_Shared.Models;

namespace Store_APP.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            var productsmodels = new List<ProductModel>();

            await _context.Products
                .ForEachAsync(p =>
                {
                    var pro = new ProductModel
                    {
                        Product = p
                    };
                    productsmodels.Add(pro);
                });
            return productsmodels;
        }

        public async Task<ProductModel> Get(string Id)
        {
            var getProduct = await _context.Products.Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == Id);
            var Getimg = _context.Images.Where(p => p.ProductImgId == Id);

            List<Images> imgProd = new();
            await Getimg.ForEachAsync(i => { imgProd.Add(i); });
            var product = new ProductModel
            {
                Product = getProduct,
                ProductImages = imgProd
            };
            return product;
        }

        public async Task<Product> Post(Product model, List<IFormFile> image)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            foreach (var file in image)
            {
                Images images = new();
                MemoryStream ms = new();

                await file.CopyToAsync(ms);
                images.Image = ms.ToArray();

                images.ProductImgId = model.Id;

                await _context.AddAsync(images);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task Delete(string Id)
        {
            var DeleteProduct = await _context.Products.FindAsync(Id);
            var deleteimage = await _context.Images.FindAsync(Id);

            _context.Products.Remove(DeleteProduct);
            if (deleteimage is not null) _context.Images.Remove(deleteimage);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetByCategory(string CategoryId)
        {
            var productModels = new List<ProductModel>();

            await _context.Products
                .Include(p => p.ProductCategory)
                .Where(p => p.ProductCategoryId == CategoryId).ForEachAsync(p =>
                {
                    var pro = new ProductModel
                    {
                        Product = p
                    };
                    productModels.Add(pro);
                });


            return productModels;
        }
    }
}