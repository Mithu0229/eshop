
var builder = WebApplication.CreateBuilder(args);

//services

builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddBasketModule(builder.Configuration);
builder.Services.AddOrderingModule(builder.Configuration);
var app = builder.Build();

//Configuration
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();


//app.MapGet("/", () => "Hello World!");

app.Run();
