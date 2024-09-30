using Elasticsearch.Models;
using Elasticsearch.Services;
using Nest;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();


//Elasticsearch config
var settings = new ConnectionSettings(new Uri("http://localhost:9200/")).DefaultIndex("elasticsearchdemo-${date:format=yyyy.MM.dd}");
var client = new ElasticClient(settings);

builder.Services.AddSingleton(client);
builder.Services.AddScoped<IElasticsearchService<Author>, ElasticsearchService<Author>>();


// Register IServiceCollection for later access
builder.Services.AddSingleton(builder.Services);

var app = builder.Build();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers(); //Enable the routings for all the controllers
app.Run();
