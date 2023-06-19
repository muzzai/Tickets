
using EventCatalogService.Infrastructure;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var elasticSettings = builder.Configuration.GetSection("ElasticsearchSettings");
string url = elasticSettings.GetValue<string>("Url")!;
var indexName = "event_catalog";

var connectionSettings = new ConnectionSettings(new Uri(url))
  .DefaultIndex(indexName)
  .BasicAuthentication("elastic", "elastic");
var elasticClient = new ElasticClient(connectionSettings);
builder.Services.AddSingleton(elasticClient);

var createIndexResponse = elasticClient.Indices.Create("event-catalog", c => c
  .Map<Document>(m => m
    .AutoMap<Company>() 
    .AutoMap(typeof(Employee)) 
  )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
