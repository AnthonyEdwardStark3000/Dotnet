using Microsoft.AspNetCore.Mvc;
using Views.Models;
namespace Views.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class HomeController:Controller{
        [Route("index")]
        public IActionResult Index(){
            ViewData["appTitle"]="ASP.net CORE WebApp Demo application";

            Person person = new Person(){Name="Hugh Jacksman",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Male,
            //  DateOfBirth=null 
            };
            List<Person>people = new List<Person>(){
            new Person(){Name="Hugh Jacksman",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Male,
            },
            new Person(){Name="Mark Ruffallo",
            DateOfBirth=Convert.ToDateTime("19-08-2000"),
            PersonGender = Gender.Male,
            },
            new Person(){Name="Ana de armmas",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Female,
            }
            };

            // ViewData["people"] = people;
            // ViewData["person"] = person;

            ViewBag.people = people;
            ViewBag.person = person;

            Person SamplePerson = person;
            return View(); // it will check for file named as Index.cshtml from the folder Views / Home
        }
    }
}