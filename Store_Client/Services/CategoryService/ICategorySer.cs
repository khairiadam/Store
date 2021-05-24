using Store_Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store_Client.Services.CategoryService
{
    public interface ICategorySer
    {
        IEnumerable<Category> Get();
        Task<Category> GetAsync(string id);
    }

}
