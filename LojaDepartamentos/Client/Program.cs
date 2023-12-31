
using LojaDepartamentos.Client.Services;
using LojaDepartamentos.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:36331";
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri(baseUrl)
});
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IGerenciaProdutosLocalStorageService,
	GerenciaProdutosLocalStorageService>();

builder.Services.AddScoped<IGerenciaCarrinhoItensLocalStorageService,
	GerenciaCarrinhoItensLocalStorageService>();

await builder.Build().RunAsync();