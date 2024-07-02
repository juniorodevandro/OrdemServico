using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using OrdemServico.Web;
using OrdemServico.Web.Services;
using OrdemServico.Web.Layout.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7006";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

builder.Services.AddScoped<SnackbarService>();
//builder.Services.AddScoped<MudTableBase>();

// MUDBLAZOR
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.HideTransitionDuration = 100;
    config.SnackbarConfiguration.ShowTransitionDuration = 100;
});

// INTERFACE
builder.Services.AddScoped<TitleService>();

builder.Services.AddScoped<IPessoa, PessoaService>();

builder.Services.AddScoped<DialogService>();


await builder.Build().RunAsync();
