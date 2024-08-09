using modelValidations.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options=>{
    // options.ModelBinderProviders.Insert(0,new PersonBinderProvider()); // Making use of the customBinder Provider that we have created.
}); // Adding controllers with services for DI in future.
builder.Services.AddControllers().AddXmlSerializerFormatters(); // Adding controllers with Xml serializer formatter to read and convert the xml data from the request body.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
