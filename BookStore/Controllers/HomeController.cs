using Microsoft.AspNetCore.Mvc;
namespace IActionResultExample.Controllers
{
    public class HomeController:Controller{
        [Route("bookstore")]
        // url :/bookstore?bookid=5&isloggedin=true
        public IActionResult Index(){
            if(!Request.Query.ContainsKey("bookid")){
                return BadRequest("Book Id is not supplied!");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book Id should contain a value");
            }
            int bookId = Convert.ToInt32(
            ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId<=1 && bookId >= 100)
            {
                Response.StatusCode = 400;
                return Content("Book Id should be between 1 and 100");
            }
            //?isLoggedIn is present in the query
            if (!Convert.ToBoolean(Request.Query["isLoggedIn"])) {
                Response.StatusCode = 401;
                return Content("User must be authenticated to continue!");
            }
            // return File("/sample.pdf","application/pdf");
            // return new RedirectToActionResult("Books","Store",new {});
            // return new RedirectToActionResult("Books","Store" ); //302 redirect 
            // return new RedirectToActionResult("Books", "Store",new {}, permanent:true); // 301 moved permanently

            // return new RedirectToActionResult("Action method name","controller name");
            // return RedirectToActionPermanent("Books", "Store",new {Edition = 12});

            // Redirect to Books action in StoreController with Edition parameter
            return RedirectToActionPermanent("Books", "Store", new { Edition = 12 }); // Pass Edition parameter

    }
    }
}