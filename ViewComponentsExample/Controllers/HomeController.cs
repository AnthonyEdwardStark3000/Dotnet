using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers{
    public class HomeController:Controller{
        [Route("/")]
        public IActionResult Index(){
            return View();
        }

        [Route("/about")]
        public IActionResult About(){
            return View();
        }
        
        [Route("/friends-list")]
        public IActionResult LoadFriendsList(){
        PersonGridModel personGridModel = new PersonGridModel(){
            GridTitle = "Person Details",
            Persons = new List<Person>(){
                new Person(){
                    PersonName = "Person 1",JobTitle="Coding"
                },
                new Person(){
                    PersonName = "Person 2",JobTitle="Sales Manager"
                },
                new Person(){
                    PersonName = "Person 3",JobTitle="HR"
                },
            }
            };
            return ViewComponent("Grid", new { grid = personGridModel });
        }
    }
}