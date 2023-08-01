using AppView;
using AppView.IServices;
using AppView.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7075/")
});
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IBillServices, BillServices>();
builder.Services.AddScoped<IBillDetailsServices, BillDetailsServices>();

await builder.Build().RunAsync();
