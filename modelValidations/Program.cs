var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Adding controllers with services for DI in future.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
