using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Driver.Configuration;


namespace Driver;

public class Init
{
    [ThreadStatic]
    private protected static EventFiringWebDriver? _driver;

  //  protected static readonly ConfigSettings _driverConfig = Config.GetConfigSettings();

    protected void InitializeDriver(BROWSERTYPE browserType)
    {
        IWebDriver driver;

        switch (browserType)
        {
            case BROWSERTYPE.EDGE:

                driver = new EdgeDriver();

                break;

            case BROWSERTYPE.FIREFOX:

                driver = new FirefoxDriver();

                break;

            case BROWSERTYPE.CHROME:
            default:

                driver = new ChromeDriver();

                break;
        }

        _driver = new EventFiringWebDriver(driver);     
        
        _driver.ExceptionThrown += new EventHandler<WebDriverExceptionEventArgs>(OnException);

        _driver.FindingElement += new EventHandler<FindElementEventArgs>(OnFindingElement);

    }

    private readonly string[] TAGS = new string[] { "div", "a", "span", "area", "b" };


    private By by;

    public void OnFindingElement(object sender, FindElementEventArgs e)
    {
        by = e.FindMethod;
    }


    public void OnException(object sender, WebDriverExceptionEventArgs e)
    {
        if (e != null)
        {
            if (e is NotFoundException)
            {

            }
            else
            {

            }
        }
    }
}


public enum BROWSERTYPE
{
    CHROME,
    FIREFOX,
    EDGE
}


