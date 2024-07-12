using CleanArchitecture.BlazorUI;
using CleanArchitecture.BlazorUI.Contracts;
using CleanArchitecture.BlazorUI.Services;
using CleanArchitecture.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7104/"));
builder.Services.AddScoped<ICustomerService, CustomerService>();

await builder.Build().RunAsync();
