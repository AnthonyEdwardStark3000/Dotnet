using Microsoft.AspNetCore.Mvc;
using modelValidations.Models;
namespace modelValidations.Controllers{
    public class HomeController:Controller{
        public IActionResult Index(Person person){
            return Content($"{person}"); // Automatically calls the ToString() of the person Model
        }
    }
}