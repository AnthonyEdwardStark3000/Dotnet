using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;
namespace PartialViews.Controllers{
    public class HomeController:Controller{
        [Route("/")]
        public IActionResult Index(){
            return View();
        }

        [Route("about")]
        public IActionResult About(){
            return View();
        }

        [Route("programmingLanguages")]
        public IActionResult ProgrammingLanguages(){
           ListModel listmodel = new ListModel(){
            ListTitle = "Programming Languages",
           }; 
            return View();
        }
    }
}