using Microsoft.AspNetCore.Components;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Client_Blzr.Pages
{
    public partial class Index 
    {
  
        private List<Product> products { get; set; }
        //IProductService _productService;

        //protected override async Task OnInitializedAsync()
        //{
        //    //var pr = await _productService.GetAll();
        //    //var i = pr.Count;
        //}
     

        //protected override async Task OnParametersSetAsync()
        //{
        //    await _productService.LoadProducts(CategoryId);

        //    if (CategoryId != null)
        //    {
        //        //category = CategoryService.Categories.FirstOrDefault(c => c.Url.ToLower().Equals(CategoryId.ToLower()));
        //    }
        //    else
        //    {
        //        _category = null;
        //    }

        //    //await StatsService.IncrementVisits();
        //    //await StatsService.GetVisits();
        //}
    }
}
