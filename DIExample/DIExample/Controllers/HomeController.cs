using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
using NLog;
using Microsoft.Extensions.DependencyInjection;
using Autofac;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        //Reference Variable 
        //private readonly CitiesService _citiesService;
        private readonly ICitiesService _citiesService; //DI
        private readonly ICitiesService _citiesService1; //DI
        private readonly ICitiesService _citiesService2; //DI
        private readonly ICitiesService _citiesService3; //DI

        // private readonly IServiceScopeFactory _serviceScopeFactory; // For IOC container
        private readonly ILifetimeScope _lifetimeScope; // Autofac instead of default IOC container

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceProvider _serviceProvider;

        //Constructor
        // public HomeController(ICitiesService citiesService, ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory) // IOC container
        public HomeController(ICitiesService citiesService, ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceProvider serviceProvider, ILifetimeScope serviceScopeFactory) //  Autofac
        {
            // Create Object of Cities service class
            // _citiesService = new CitiesService(); // Instantiating the service
            _citiesService = citiesService;// DI
            _citiesService1 = citiesService1;// DI
            _citiesService2 = citiesService2;// DI
            _citiesService3 = citiesService3;// DI

            _serviceProvider = serviceProvider;
            // _serviceScopeFactory = serviceScopeFactory; // Default IOC container
            _lifetimeScope = serviceScopeFactory;
        }
        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService _citiesService)
        {
            var serviceDescriptor = _serviceProvider.GetService<IServiceCollection>()?
    .FirstOrDefault(sd => sd.ServiceType == typeof(ICitiesService));

            if (serviceDescriptor!=null) {
            var serviceLifetime = serviceDescriptor.Lifetime;
            var instanceId = _citiesService.ServiceInstanceId;
            var instanceId1 = _citiesService1.ServiceInstanceId;
            var instanceId2 = _citiesService2.ServiceInstanceId;
            var instanceId3 = _citiesService3.ServiceInstanceId;

                logger.Info($"From Home Controller | Current DI is | {serviceLifetime} and the istance ID created is |\n instanceId:{instanceId}|\ninstanceId1:{instanceId1}|\ninstanceId2:{instanceId2}|\ninstanceId3:{instanceId3}");
            }
            else
            {
                logger.Error($"From Home Controller | Current DI is | null");
            }
            List<string> cities = _citiesService.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_4 = _citiesService3.ServiceInstanceId;

            // using (IServiceScope scope= _serviceScopeFactory.CreateScope()) { // Default IOC container
            using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope()) { // Autofac
                // Inject CitiesService
                // ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>(); //Default IOC container
                ICitiesService citiesService = scope.Resolve<ICitiesService>(); // Autofac
                
                ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceInstanceId;
                // end of scope, automatically calls CitiesService.Dispose()
            }
                return View(cities); // sending it as model object to the View
        }
    }
}
