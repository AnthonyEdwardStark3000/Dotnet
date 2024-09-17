using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.Add(new ServiceDescriptor(
typeof(ICitiesService),typeof(CitiesService),ServiceLifetime.Scoped
));

// Register IServiceCollection for later access
builder.Services.AddSingleton(builder.Services);

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers(); //Enable the routings for all the controllers
app.Run();
