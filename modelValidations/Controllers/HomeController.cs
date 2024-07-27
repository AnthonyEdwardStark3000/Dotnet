using Microsoft.AspNetCore.Mvc;
using modelValidations.Models;
using NLog;

namespace modelValidations.Controllers{

    public class HomeController:Controller{
        private Logger logger = LogManager.GetCurrentClassLogger();
        [Route("register")]
        public IActionResult Index(Person person){
            logger.Debug($"Hit the API: /register");
            return Content($"{person}"); // Automatically calls the ToString() of the person Model
        }
    }
}

