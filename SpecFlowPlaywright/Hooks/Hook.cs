using System;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;
[assembly:Parallelizable(ParallelScope.Fixtures)]


namespace SpecFlowPlaywright.Hooks
{
    [Binding]
    public class Hooks
    {
        private IBrowser? Browser { get; set; }

        private IBrowserContext context;

        [Before]

        public async Task BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Timeout = 50000
            });
            context = await Browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 },
                    RecordVideoDir = "C:\\Users\\zarko.acimovic\\Playwright\\videos",
                    AcceptDownloads = true,
                    ColorScheme = ColorScheme.Dark
                });


            await context.Tracing.StartAsync(new TracingStartOptions
            {
                Title = "zare" + context.ToString(), //Note this is for MSTest only. 
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });


        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (Browser != null)
            {
                //context = await Browser.NewContextAsync();


                await context.Tracing.StopAsync(new TracingStopOptions
                {
                    Path = "C:\\Users\\zarko.acimovic\\Playwright\\Zarko.zip" //+ context.ToString()
                });

                await context.CloseAsync();
                await Browser.CloseAsync();
            }

        }
    }

    
}