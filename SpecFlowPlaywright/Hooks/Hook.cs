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
            

        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            

        }
    }

    
}