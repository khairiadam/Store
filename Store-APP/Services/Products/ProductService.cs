using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Store_API.Data;
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



        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(string Id)
        {
            var getProduct = await _context.Products.FindAsync(Id);


            return getProduct;
        }

        public async Task<Product> Post(Product model, List<IFormFile> image)
        {


            Category category = new();
            category.Id = model.ProductCategoryId;


            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
            foreach (var file in image)
            {


                Images images = new();


                MemoryStream ms = new();
                await file.CopyToAsync(ms);
                images.Image = ms.ToArray();
                images.Id = model.Id;


                await _context.Images.AddAsync(images);
                await _context.SaveChangesAsync();

            }




            return model;
        }

        public async Task Delete(string Id)
        {



            var DeleteProduct = await _context.Products.FindAsync(Id);
            var deleteimage = await _context.Images.FindAsync(Id);

            _context.Products.Remove(DeleteProduct);
            _context.Images.Remove(deleteimage);

            await _context.SaveChangesAsync();
        }



        public async Task Update(Product product)
        {

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}