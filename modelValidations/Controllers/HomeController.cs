using Microsoft.AspNetCore.Mvc;
using modelValidations.Models;
namespace modelValidations.Controllers{
    public class HomeController:Controller{
        public IActionResult Index(){
            return View();
        }
    }
}