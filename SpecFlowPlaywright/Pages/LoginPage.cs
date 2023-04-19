using Microsoft.Playwright;

namespace SpecFlowPlaywright.Pages;

public class LoginPage
{
    private IPage _page;
    public LoginPage(IPage page) => _page = page;
    
    private ILocator _lnkLogin => _page.Locator("text=Swag Labs");
    private ILocator _txtUserName => _page.Locator("#user-name");
    private ILocator _txtPassword => _page.Locator("#password");
    private ILocator _btnLogin => _page.Locator("#login-button");
    private ILocator _lnkEmployeeDetails => _page.Locator("text='Sauce Labs Backpack'");    
    private ILocator _lnkEmployeeLists => _page.Locator("text='Sauce Labs Bike Light'");
    
    public async Task ClickLogin()
    {
        await _page.RunAndWaitForNavigationAsync(async () =>
        {
            await _lnkLogin.ClickAsync();
        }, new PageRunAndWaitForNavigationOptions
        {
            UrlString = "**/inventory.html"
        });
    }

    public async Task ClickEmployeeList() => await _lnkEmployeeLists.ClickAsync();
    
    public async Task Login(string userName, string password)
    {
        await _txtUserName.FillAsync(userName);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();

}