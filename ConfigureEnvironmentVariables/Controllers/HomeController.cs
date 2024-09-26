using Microsoft.AspNetCore.Mvc;
using NLog;
namespace ConfigureEnvironmentVariables.Controllers{
    public class HomeController:Controller{
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IWebHostEnvironment _webHostEnvironment;

        //Injecting the WebHostEnvironment for accessing the Environmental variables.
        public HomeController(IWebHostEnvironment webHostEnvironment){
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public IActionResult Index(){
            var mode = string.Empty;
            if(_webHostEnvironment.IsDevelopment()){
                mode = "Development";
            }else if(_webHostEnvironment.IsStaging()){
                mode = "Staging";    
            }else{
                mode = "Production";
            }
            logger.Info($"Inside the Get request of |{nameof(HomeController)}|and {nameof(Index)} method | and is running in {mode} Mode");
            ViewBag.CurrentEnvironment = mode;
            return View();
        }
    }
}