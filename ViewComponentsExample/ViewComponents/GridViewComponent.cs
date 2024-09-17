using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents{
    public class GridViewComponent: ViewComponent{
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid){ // Mandatory method for ViewComponent
        // PersonGridModel model = new PersonGridModel(){
        //     GridTitle = "Persons List",
        //     Persons = new List<Person>(){
        //         new Person(){
        //             PersonName = "Person 1", JobTitle = "Job 1"
        //         },
        //         new Person(){
        //             PersonName = "Person 2", JobTitle = "Job 2"
        //         },
        //         new Person(){
        //             PersonName = "Person 3", JobTitle = "Job 3"
        //         },
        //         new Person(){
        //             PersonName = "Person 4", JobTitle = "Job 4"
        //         },
        //     }
        // };
            // ViewBag.Grid = model;
        // The View here is not a regular view , it's an partial view.
            // return View("Sample"); // Invoke a partial view from Views/ Shared / Components / Grid / Default.cshtml  
            // return View("Sample",model); // Invoke a partial view from Views/ Shared / Components / Grid / Default.cshtml  
            // View is tightly coupled to the Model PersonGridModel
            return View("Sample",grid); // Invoke a partial view from Views/ Shared / Components / Grid / Default.cshtml  
        }
    }
}