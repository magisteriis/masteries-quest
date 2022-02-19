using Blazored.LocalStorage;
using ChampionMasteryGg;
using MasteriesQuest;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RiotGames;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#wrapper");
builder.RootComponents.Add<HeadOutlet>("head::after");

RiotGamesApiHttpClient.BaseAddressFormat = "https://masteries.quest/api/{0}/";
ChampionMasteryGgClient.BaseAddress = "https://masteries.quest/api/highscores/";
ChampionMasteryGgClient.Encoding = ChampionMasteryGgEncoding.Json;

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

await builder.Build().RunAsync();