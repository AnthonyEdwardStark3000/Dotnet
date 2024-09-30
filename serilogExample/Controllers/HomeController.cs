using Microsoft.AspNetCore.Mvc;
using NLog;


namespace serilogExample.Controllers{
    public class HomeController:Controller{
        private static Logger logger = LogManager.GetCurrentClassLogger();
        [Route("/")]
        public void index(){
            logger.Info("Starting up the host");
            logger.Error("Starting up the host");
            logger.Warn("Starting up the host");
        }
    }
}