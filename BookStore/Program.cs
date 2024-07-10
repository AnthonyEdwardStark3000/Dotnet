var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseRouting();
app.UseCors("*"); // Apply CORS policy
app.MapControllers();
app.Run();
