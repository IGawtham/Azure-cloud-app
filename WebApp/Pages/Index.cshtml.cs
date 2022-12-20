using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService= productService;
        }

        public void OnGet()
        {
            products=_productService.GetProducts();
        }
    }
}