using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{Edition}")]
        public IActionResult Books(string Edition)
        {
            int edition = Convert.ToInt32(Request.RouteValues["Edition"]);
            return Content($"<h1>BookStore</h1> {edition}","text/html");
        }
    }
}
