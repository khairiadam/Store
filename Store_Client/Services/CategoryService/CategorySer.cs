using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Store_Client.Services.CategoryService
{
    public class CategorySer : ICategorySer
    {
        HttpClient _client;

        public CategorySer(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:4000/api/");
        }

        public IEnumerable<Category> Get()
        {
            IEnumerable<Category> categories = null;

            //HTTP GET
            var responseTask = _client.GetAsync("Category");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Category>>();
                readTask.Wait();

                categories = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                categories = Enumerable.Empty<Category>();
            }
            return categories;
        }

        public Category Get(string id)
        {
            Category category = null;

            //HTTP GET
            var responseTask = _client.GetAsync($"Category/{id}");
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Category>();
                readTask.Wait();

                category = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                category = null;
            }
            return category;
        }
    }

}
