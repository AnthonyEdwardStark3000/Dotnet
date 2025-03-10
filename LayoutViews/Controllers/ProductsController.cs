using Microsoft.AspNetCore.Mvc;

namespace LayoutViews.Controllers{
    [ApiController]
    // [Route("[controller]")]
    public class ProductsController:Controller{
        [Route("products")]
        public IActionResult Index(){
            return View();
        }

        // url : -  search-products/1
        [Route("search-products/{ProductID?}")]
        public IActionResult Search(int? ProductID){
            ViewBag.ProductID = ProductID;
            return View();
        }
        [Route("order-product")]
        public IActionResult Order(){
            return View();
        }
    }
}