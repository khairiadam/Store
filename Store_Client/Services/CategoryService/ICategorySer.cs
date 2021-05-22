using Store_Shared.Models;
using System.Collections.Generic;

namespace Store_Client.Services.CategoryService
{
    public interface ICategorySer
    {
        IEnumerable<Category> Get();
        Category Get(string id);
    }

}
