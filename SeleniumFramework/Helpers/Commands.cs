namespace Driver.Helpers;


public abstract class Commands : Waits
{

    #region Basic UI Operations -  Wrapper methods to incorporate encapsulate the webdriver object 

    protected void Click(string by) =>

        InteractableElement(by).Click();


    protected void ClearText(string by) =>

        InteractableElement(by).Clear();


    protected string GetText(string by) =>

         VisibleElement(by).Text.Trim();


    protected string GetHtmlAttribute(string by, string htmlAttribute) =>

         ExistentElement(by).GetAttribute(htmlAttribute);


    protected void SetText(string by, object? text)
    {
        if (text != null)
        {
            ClearText(by);

            InteractableElement(by).SendKeys(text.ToString());
        }
    }


    protected bool Exists(By by)
    {
        try
        {
            _driver.FindElement(by);

            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    protected bool IsDisplayed(string by) =>

        ExistentElement(by).Displayed;





    #endregion


    #region Navigation Operations

    protected string GetUrl()
    {
        return _driver.Url;
    }


    protected void GoToUrl(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    protected void MaxWindow()
    {
        _driver.Manage().Window.Maximize();
    }

    protected void NavigateRefresh() =>

        _driver.Navigate().Refresh();

    protected void QuitDriver()
    {
        if (_driver != null)
        {
            _driver.Quit();
        }
    }
    protected void SwitchToIFrame(string by) =>

        _driver.SwitchTo().Frame(ExistentElement(by));


    protected void SwitchToDefaultContent() =>

        _driver.SwitchTo().DefaultContent();


    protected void AcceptJavaScriptAlert() =>

        ExistentAlert.Accept();


    protected string GetTextFromJavaScriptAlert() =>

        ExistentAlert.Text.Trim();


    protected void SetCookies(ReadOnlyCollection<Cookie> cookies)
    {
        DeleteAllCookies();

        foreach (Cookie cookie in cookies)

            _driver.Manage().Cookies.AddCookie(cookie);
    }

    protected void DeleteAllCookies() =>

            _driver.Manage().Cookies.DeleteAllCookies();


    protected void SetDropDownValue(string by, object obj)
    {
        if (obj != null)
        {
            VisibleSelect(by).SelectByValue(obj.ToString().Trim());
        }
    }

    protected void SetDropDownText(string by, object obj)
    {
        if (obj != null)
        {
            VisibleSelect(by).SelectByText(obj.ToString().Trim());
        }
    }

    protected void SetDropDownIndex(string by, int index)
    {
        VisibleSelect(by).SelectByIndex(index);
    }


    protected string GetDropDownSelectedOption(string by)
    {
        return VisibleSelect(by).SelectedOption.Text.Trim();
    }



    protected IEnumerable<string> GetDropDownOptions(string by)
    {
        foreach (IWebElement option in VisibleSelect(by).Options)
        {
            yield return option.Text.Trim();
        }
    }


    protected void SetTextElements(string by, string text)
    {
        VisibleElements(by).ToList().ForEach(elements => SetText(by, text));
    }



    protected IEnumerable<string> GetHtmlAttibutesElements(string by, string attribute)
    {
        foreach (IWebElement element in VisibleElements(by))
        {
            yield return element.GetAttribute(attribute);
        }
    }


    protected IEnumerable<string> GetTextFromElements(string by)
    {
        foreach (IWebElement element in ExistentElements(by))
        {
            yield return element.Text.Trim();
        }
    }

    protected void ClickElements(string by)
    {
        VisibleElements(by).ToList().ForEach(e => e.Click());
    }


    protected int GetNumberOfElements(string by)
    {
        return ExistentElements(by).Count;
    }


    protected void RightClick(string by)
    {
        Actions.ContextClick(VisibleElement(by)).Perform();
    }






    #endregion
}