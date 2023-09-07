using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Driver.Helpers;
using PageObjects.PageHelpers;


[assembly: LevelOfParallelism(2)]
[assembly: Parallelizable(ParallelScope.All)]



namespace Tests
{
    [TestFixture]
    public class BaseTest : Commands
    {
        protected static ReadOnlyCollection<Cookie> _cookies { private get; set; }

        [TearDown]
        protected virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure
               || TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
              //  LogException(TestContext.CurrentContext);
            }

            QuitDriver();
        }

        [OneTimeTearDown]
        protected virtual void OneTimeTearDown()
        {
            TestContext.ResultAdapter results = TestContext.CurrentContext.Result;
         
            
            int failCount = results.FailCount;
            int passCount = results.PassCount;

        }

        [SetUp]
        public void Setup()
        {
            InitializeDriver(Driver.BROWSERTYPE.CHROME);

            MaxWindow();

            GoToUrl(Links.YouTubeHomePage);
        }

    }
}
