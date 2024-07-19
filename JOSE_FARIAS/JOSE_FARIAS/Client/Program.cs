using Blazored.SessionStorage;
using JOSE_FARIAS.Client;
using JOSE_FARIAS.Client.Extensiones;
using JOSE_FARIAS.Client.Services.Contracts;
using JOSE_FARIAS.Client.Services.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddScoped<ITareaService, TareaService>();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
