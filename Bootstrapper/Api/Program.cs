

var builder = WebApplication.CreateBuilder(args);

//services

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration); 

var app = builder.Build();
app.MapCarter();

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
