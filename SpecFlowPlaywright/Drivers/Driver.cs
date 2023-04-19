using Microsoft.Playwright;

namespace SpecFlowPlaywright.Drivers;

public class Driver : IDisposable
{
    private readonly Task<IPage> _page;
    private IBrowser? _browser;

    private IBrowserContext context;

    public Driver()
    {
        _page = InitializePlaywright();
    }

    public IPage Page => _page.Result;

    public async void Dispose()
    {
        if (_browser != null)
        {
            await Page.Context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = "video2.zip" 
            });

            await context.CloseAsync();
            await _browser.CloseAsync();
        }
        
    }

    private async Task<IPage> InitializePlaywright()
    {
        //Playwright
        var playwright = await Playwright.CreateAsync();
        //Browser
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });


        IPage _page = await _browser.NewPageAsync();

        await _page.Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = "zare23care", //Note this is for MSTest only. 
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        return _page;
    }



}