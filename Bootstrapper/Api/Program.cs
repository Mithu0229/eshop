using Basket;
using Catalog;
using Ordering;
var builder = WebApplication.CreateBuilder(args);

//services

builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddBasketModule(builder.Configuration);
builder.Services.AddOrderingModule(builder.Configuration);
var app = builder.Build();

//

app.MapGet("/", () => "Hello World!");

app.Run();
