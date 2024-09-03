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
            ListItems = new List<string>(){
                "Java",
                "Python",
                "C#",
                "dotnet",
                "Angular",
                "Node JS"
            }
           }; 
            return PartialView("_ListPartialView",listmodel);
        }
    }
}