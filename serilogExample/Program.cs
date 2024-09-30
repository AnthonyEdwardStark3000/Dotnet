// using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Using serilog
// builder.Host.UseSerilog((context,config)=>config.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();
app.MapControllers();
// app.UseSerilogRequestLogging();
app.Run();