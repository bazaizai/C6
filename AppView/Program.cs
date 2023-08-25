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
builder.Services.AddScoped<IComboDetailServices, ComboDetailServices>();
builder.Services.AddScoped<ICartDetailService, CartDetailService>();


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRoleServices, RoleServices>();

await builder.Build().RunAsync();
