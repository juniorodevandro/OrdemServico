using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using OrdemServico.Web;
using OrdemServico.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7006";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

// MUDBLAZOR
builder.Services.AddMudServices();

// INTERFACE
builder.Services.AddScoped<TitleService>();

builder.Services.AddScoped<IPessoa, PessoaService>();

await builder.Build().RunAsync();
