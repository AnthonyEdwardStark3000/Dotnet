using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents{
    public class GridViewComponent: ViewComponent{
        public async Task<IViewComponentResult> InvokeAsync(){ // Mandatory method for ViewComponent
        // The View here is not a regular view , it's an partial view.
            return View("Sample"); // Invoke a partial view from Views/ Shared / Components / Grid / Default.cshtml  
        }
    }
}