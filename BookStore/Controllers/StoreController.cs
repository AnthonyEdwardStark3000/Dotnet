using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books(string id)
        {
            int Id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>BookStore</h1>{Id} ","text/html");
        }

        [Route("store/check")]
        public IActionResult Check()
        {
            return Content($"<h1>BookStore check function</h1>","text/html");
        }
    }
}
