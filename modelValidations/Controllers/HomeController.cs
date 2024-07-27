using Microsoft.AspNetCore.Mvc;
using modelValidations.Models;
namespace modelValidations.Controllers{
    public class HomeController:Controller{
        [Route("register")]
        public IActionResult Index(Person person){
            return Content($"{person}"); // Automatically calls the ToString() of the person Model
        }
    }
}