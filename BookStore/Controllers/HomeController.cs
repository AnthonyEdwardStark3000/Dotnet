using Microsoft.AspNetCore.Mvc;
namespace IActionResultExample.Controllers
{
    public class HomeController:Controller{
        [Route("bookstore")]
        // url :/bookstore?bookid=5&isloggedin=true
        public IActionResult Index(int? bookid, bool? isLoggedIn){
            if(bookid.HasValue==false){
                return BadRequest("Book Id is not supplied!");
            }
            if(bookid<=0){
                return Content("Book Id cannot be less than or equal to zero!");
            }
            if (bookid<=1 && bookid >= 100)
            {
                Response.StatusCode = 400;
                return Content("Book Id should be between 1 and 100");
            }
            //?isLoggedIn is present in the query
            if (isLoggedIn==false) {
                Response.StatusCode = 401;
                return Content("User must be authenticated to continue!");
            }
            return Content($"The entered Book ID is: {bookid}","text/plain");
    }
    }
}
