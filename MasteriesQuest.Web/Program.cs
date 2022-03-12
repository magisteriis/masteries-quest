using Blazored.LocalStorage;
using MasteriesQuest;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RiotGames;
using Sentry;

// Capture blazor bootstrapping errors
using var sdk = SentrySdk.Init(o =>
{
    o.Dsn = "https://343d1808f4484ecbbb750364d3db023a@o1160036.ingest.sentry.io/6244373";
    o.AutoSessionTracking = true;
#if DEBUG
    o.Debug = true;
#endif
});
try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#wrapper");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Logging.SetMinimumLevel(LogLevel.Debug);
    // Captures logError and higher as events
    builder.Logging.AddSentry(o => o.InitializeSdk = false);

    RiotGamesApiHttpClient.BaseAddressFormat = "https://masteries.quest/api/{0}/";

    builder.Services.AddBlazoredLocalStorage();
    builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

    await builder.Build().RunAsync();
}
catch (Exception e)
{
    SentrySdk.CaptureException(e);
    await SentrySdk.FlushAsync(TimeSpan.FromSeconds(2));
    throw;
}
