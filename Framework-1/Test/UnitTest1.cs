using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using OpenQA.Selenium.Interactions;
using Framework_1.FrameworkFiles;
using Microsoft.Extensions.Configuration;
namespace Framework_1
{
    public class Tests
    {
        private DriverManager driverManager;
        private IConfiguration _config;
        private ComputeEngineConfiguration engineConfig;
        [OneTimeSetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddXmlFile("Sources/test-settings.xml").Build();
            driverManager = new DriverManager(_config);
            engineConfig = new ComputeEngineConfiguration(_config);
            WebDriver driver = driverManager.getDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");

            driver.FindElement(By.CssSelector("button.xhASFc")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("div.DzHYNd")).FindElements(By.CssSelector("div.VobRQb"))[0].Click();
            ComputeEnginePage.inputData(driver, engineConfig);
            Thread.Sleep(1000);
            
            driver.FindElements(By.CssSelector("div.OCM48"))[0].FindElement(By.CssSelector("div.VfPpkd-dgl2Hf-ppHlrf-sM5MNb")).FindElement(By.TagName("button")).Click();

            driver.FindElements(By.CssSelector("div.v08BQe"))[0].FindElement(By.CssSelector("a.tltOzc")).Click();

            IReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            foreach (string handle in windowHandles)
            {
                if (handle != driver.CurrentWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        [Test]
        public void Verify()
        {
            try
            {
                var text = driverManager.getDriver().FindElements(By.CssSelector("span.Kfvdz"));
                Assert.That(text[2].Text, Does.Contain(_config["TestConfiguration:machineType"]));
                Assert.That(text[4].Text, Does.Contain(_config["TestConfiguration:gpuType"]));
                Assert.That(text[6].Text, Does.Contain(_config["TestConfiguration:ssdSize"]));
                Assert.That(text[17].Text, Does.Contain(_config["TestConfiguration:region"]));
            }
            catch (AssertionException ex)
            {
                ScreenshotUtil.takeScreenshot(driverManager.getDriver());
            }
            
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driverManager.closeDriver();
        }
    }
}