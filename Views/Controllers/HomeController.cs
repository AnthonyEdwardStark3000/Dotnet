using Microsoft.AspNetCore.Mvc;
using Views.Models;
namespace Views.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class HomeController:Controller{
        // [Route("index")]
        public IActionResult Index(){
            ViewData["appTitle"]="ASP.net CORE WebApp Demo application";

            Person person = new Person(){Name="Hugh Jacksman",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Male,
            //  DateOfBirth=null 
            };
            List<Person>people = new List<Person>(){
            new Person(){Name="HughJacksman",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Male,
            },
            new Person(){Name="MarkRuffallo",
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

            // ViewBag.people = people;
            ViewBag.person = person;

            Person SamplePerson = person;
            return View(people); // it will check for file named as Index.cshtml from the folder Views / Home
        }
        // Another action method to bind Model of index.cshtml to a single property 
        [Route("person-details/{name}")]
        public IActionResult Details(string? name){
            if(name == null){
                return Content("Person Name cannot be null !");
            }
            List<Person>people = new List<Person>(){
            new Person(){Name="HughJacksman",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Male,
            },
            new Person(){Name="MarkRuffallo",
            DateOfBirth=Convert.ToDateTime("19-08-2000"),
            PersonGender = Gender.Male,
            },
            new Person(){Name="Ana de armmas",
            DateOfBirth=Convert.ToDateTime("09-03-2000"),
            PersonGender = Gender.Female,
            }
            };

            Person? MatchingPerson = people.Where(temp=> temp.Name == name).FirstOrDefault();
            return View(MatchingPerson);  // Views /Home /Details.cshtml
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct(){
            Person person = new Person(){
                Name = "Person One",
                PersonGender = Gender.Male,
                DateOfBirth=Convert.ToDateTime("09-03-2000"),
            };

            Product product = new Product(){
                ProductId = 100,
                ProductName = "Product 1"
            };

            PersonAndProductWrapper personAndProductWrapper = new PersonAndProductWrapper(){
                PersonData = person,
                ProductData = product
            };
            return View("PersonAndProduct",personAndProductWrapper);
        }

        [Route("/check/allProducts")]
        public IActionResult All(){
            return View();
        }
    }
}