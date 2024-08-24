using Microsoft.AspNetCore.Mvc;
namespace Views.Controllers{
    [ApiController]
    // [Route("api/[controller]")]
    public class ProductsController: Controller{
        [Route("Products/all")]
        public IActionResult All(){
            return View(); // Will be trying to access from two locations
            // Views /Products / All.cshtml
            // Views /Shared / All.cshtml
        }
    }
}