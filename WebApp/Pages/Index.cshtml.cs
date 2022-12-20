using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;

        public void OnGet()
        {
            ProductService service= new ProductService();
            products=service.GetProducts();
        }
    }
}