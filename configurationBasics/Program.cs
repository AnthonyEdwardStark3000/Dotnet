var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/Config",async context=>{
       await context.Response.WriteAsync(app.Configuration["MyKey"]+"\n");
       await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey")+"\n");
       await context.Response.WriteAsync("Hardcoded value from appsettings.json\t"+app.Configuration.GetValue<int>("no_variable_default_value",10).ToString());
    });
});
app.MapControllers(); //Enable the routings for all the controllers
app.Run();
