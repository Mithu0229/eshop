

using Shared.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

//services
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));


builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();
app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

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
