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
        if (_browser != null )
        {
            //context = await Browser.NewContextAsync();


            await context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = "C:\\Users\\zarko.acimovic\\Playwright\\Zarko2.zip" //+ context.ToString()
            });

            await context.CloseAsync();
            await _browser.CloseAsync();
        }
        //_browser?.CloseAsync();
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

        context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 },
            RecordVideoDir = "C:\\Users\\zarko.acimovic\\Playwright\\videos",
            AcceptDownloads = true,
            ColorScheme = ColorScheme.Dark
        });

        
        await context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = "zare23" + context.ToString(), //Note this is for MSTest only. 
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });



        //Page
        return await _browser.NewPageAsync();
    }


    
}