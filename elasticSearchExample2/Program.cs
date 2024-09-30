using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var logger = LogManager.GetCurrentClassLogger();

logger.Info("Application started");

app.Run();

