using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); 
                                // Representation for IOC container

// builder.Services.Add(new ServiceDescriptor(
// typeof(ICitiesService),typeof(CitiesService),ServiceLifetime.Scoped
// ));

// builder.Services.AddTransient<ICitiesService,CitiesService>();

// builder.Services.AddScoped<ICitiesService,CitiesService>();

// builder.Services.AddSingleton<ICitiesService,CitiesService>();
// Register IServiceCollection for later access
// builder.Services.AddSingleton(builder.Services);

// Configuring Autofac
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=>{
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency(); // -> Equal to AddTransient
});

// builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=>{
//     containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope(); // -> Equal to AddScoped
// });

// builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=>{
//     containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance(); // -> Equal to AddSingleton
// });
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers(); //Enable the routings for all the controllers
app.Run();
