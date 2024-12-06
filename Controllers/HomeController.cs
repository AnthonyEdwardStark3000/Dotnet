using configurations.Models;
using Microsoft.AspNetCore.Mvc;

namespace Configurations.Controllers{
    public class HomeController:Controller{
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration){
            _configuration = configuration;
        }
        [HttpGet("/check")]
        public IActionResult CheckEndPoint(){
            ViewBag.Mykey = $"\n\t\t{_configuration.GetValue<string>("Mykey")}\n\n\t\t{_configuration["mykey"]}\n\n\t\t{_configuration.GetValue("mYkEy",":Default value if no value is present")}";
            ViewBag.Age = $"\n\t\t{_configuration.GetValue<string>("UserDetails:age")}\n\n\t\t{_configuration["UserDetails:age"]}\n\n\t\t{_configuration.GetValue("KUserDetails:age",":Default value if no value is present")}";

            // using GetSection
            IConfigurationSection section = _configuration.GetSection("UserDetails");
            ViewBag.MyNewKey = section["UserName"];
            ViewBag.MyNewAge = section["age"];

            // using optional model class
            UserDetails _userDetails = _configuration.GetSection("UserDetails").Get<UserDetails>(); 
            ViewBag.MyName = _userDetails.UserName;
            ViewBag.MyAge = _userDetails.age;

            return View();
        }
    }
}