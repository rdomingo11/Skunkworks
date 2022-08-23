using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAPIClient;
using BlazorAPIClient.DataServices;

Console.WriteLine("BlazorAPIClient has started...");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Linked in the wwwroot/index.html
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//Dependency Injection
//Registering HTTP Client
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

//Register HTTP Client factory
// builder.Services.AddHttpClient<ISpaceXDataService, RestSpaceXDataService>
//     (spds => spds.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

//Register for the GraphQL
builder.Services.AddHttpClient<ISpaceXDataService, GraphQLSpaceXDataService>
     (spds => spds.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

//Application is running
await builder.Build().RunAsync();
