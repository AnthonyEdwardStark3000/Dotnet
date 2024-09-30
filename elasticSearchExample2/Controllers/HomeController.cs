using Microsoft.AspNetCore.Mvc;
using NLog;

namespace elasticSearchExample2.Controllers{
    public class HomeController:Controller{
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // [Route("/")]
        // public void index(){
        //     logger.Info("basic routing check");
            
        //     logger.Warn("basic routing check");
        //     logger.Error("basic routing check");
        // }
    }
}