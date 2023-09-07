using OpenQA.Selenium.Interactions;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;



namespace Driver.Helpers;



public class Waits : Init
{

    public bool ToWait = true;

    private WebDriverWait Wait => new(_driver, TimeSpan.FromMilliseconds(ToWait ? 30000 : 0))
    {
        PollingInterval = TimeSpan.FromMilliseconds(500)
    };


    private By GetBy(string selector) =>

        selector.Contains(@"//") ? By.XPath(selector) : By.CssSelector(selector);


    private protected IWebElement VisibleElement(string by) =>

        Wait.Until(ElementIsVisible(GetBy(by)));


    private protected IWebElement InteractableElement(string by) =>

        Wait.Until(ElementToBeClickable(GetBy(by)));


    private protected IWebElement ExistentElement(string by) =>

        Wait.Until(ElementExists(GetBy(by)));

    private protected SelectElement VisibleSelect(string by) =>

        new SelectElement(VisibleElement(by));

    private protected ReadOnlyCollection<IWebElement> ExistentElements(string by) =>

        Wait.Until(PresenceOfAllElementsLocatedBy(GetBy(by)));

    private protected ReadOnlyCollection<IWebElement> VisibleElements(string by) =>

        Wait.Until(VisibilityOfAllElementsLocatedBy(GetBy(by)));


    private protected IAlert ExistentAlert =>

        Wait.Until(AlertIsPresent());


    private protected Actions Actions => new Actions(_driver);


}
