using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents{
    public class GridViewComponent: ViewComponent{
        Task<IViewComponentResult> InvokeAsync(){ // Mandatory method for ViewComponent
            return View(); // Invoke a partial view from Views/ Shared / Components / Grid / Default.cshtml  
        }
    }
}