using Blazorise;
using Blazorise.Bootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using FrontEnd;
using FrontEnd.Shared;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSweetAlert2();
builder.Services.AddBlazorise(options =>
{
  
})
.AddBootstrapProviders();

builder.Services.AddScoped<INavigationInterception, CustomNavigationInterceptor>();


await builder.Build().RunAsync();
