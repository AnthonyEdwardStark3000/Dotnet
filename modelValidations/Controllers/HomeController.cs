using Microsoft.AspNetCore.Mvc;
using modelValidations.Models;
using NLog;

namespace modelValidations.Controllers{

    public class HomeController:Controller{
        private Logger logger = LogManager.GetCurrentClassLogger();
        [Route("register")]
        public IActionResult Index([Bind(nameof(Person.PersonName),nameof(Person.Email),nameof(Person.Password),nameof(Person.Password),nameof(Person.ConfirmPassword),nameof(Person.Age))] Person person){
            if(!ModelState.IsValid){
                // List<string>errorsList = new List<string>();
                // foreach(var value in ModelState.Values){
                //     foreach(var error in value.Errors){
                //         errorsList.Add(error.ErrorMessage);    
                //     }
                // }
                // string errors = string.Join("\n",errorsList);
                // Can be written as
                string errors = string.Join("\n",
                ModelState.Values.SelectMany(values=>values.Errors).Select(err=>err.ErrorMessage));
                return BadRequest(errors);
            }
            logger.Debug($"Hit the API: /register");
            return Content($"{person}"); // Automatically calls the ToString() of the person Model
        }
    }
}

