var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/",async context =>{

        // reading values from configuration
        await context.Response.WriteAsync($"{app.Configuration["myKey"]}\n");
        await context.Response.WriteAsync($"{app.Configuration.GetValue<string>("myKey")}\n");
        await context.Response.WriteAsync($"{app.Configuration.GetValue<string>("Unavailable-key","Default value")}\n");
    });
});
app.MapControllers();

app.Run();
