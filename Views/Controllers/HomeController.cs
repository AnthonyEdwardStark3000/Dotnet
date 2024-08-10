using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class HomeController:Controller{
        [Route("index")]
        public IActionResult Index(){
            return View(); // it will check for file named as Index.cshtml from the folder Views / Home
        }
    }
}