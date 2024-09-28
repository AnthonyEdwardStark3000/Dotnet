using Microsoft.AspNetCore.Mvc;

namespace configurationBasics.Controllers{
    public class HomeController:Controller{
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration){
            _configuration = configuration; 
        }
        [Route("/")]
        public IActionResult Index(){

            IConfigurationSection userID = _configuration.GetSection("WeatherApi");    

            ViewBag.property = _configuration.GetValue<string>("Sample check","This will be displayed if no value if found!");
            ViewBag.UserID = _configuration.GetValue<string>("WeatherApi:clientId");

            ViewBag.UserIdentification = userID["userId"];

            ViewBag.Password = _configuration.GetValue<string>("WeatherApi:password");
            return View();
        }
    }
}