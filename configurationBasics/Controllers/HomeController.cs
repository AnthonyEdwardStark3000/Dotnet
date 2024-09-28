using Microsoft.AspNetCore.Mvc;

namespace configurationBasics.Controllers{
    public class HomeController:Controller{
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration){
            _configuration = configuration; 
        }
        [Route("/")]
        public IActionResult Index(){
            ViewBag.property = _configuration.GetValue<string>("Sample check");
            return View();
        }
    }
}