using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using OpenQA.Selenium.Interactions;
namespace Framework_1
{
    public class Tests
    {
        private ChromeDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");

            driver.FindElement(By.CssSelector("button.xhASFc")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.CssSelector("div.DzHYNd")).FindElements(By.CssSelector("div.VobRQb"))[0].Click();
            var add = driver.FindElements(By.CssSelector("button.wX4xVc-Bz112c-LgbsSe "))[1];
            for (int i = 0; i < 3; i++)
            {
                add.Click();
            }
            driver.FindElements(By.CssSelector("div.VfPpkd-O1htCb-OWXEXe-ztc6md"))[3].Click();

            driver.FindElements(By.CssSelector("ul.VfPpkd-rymPhb"))[6].FindElements(By.TagName("li"))[6].Click();

            driver.FindElements(By.CssSelector("button.eBlXUe-scr2fc-OWXEXe-uqeOfd"))[5].Click();

            var buttons = driver.FindElements(By.CssSelector("div.YgByBe"));
            while (buttons.Count < 11)
            {
                buttons = driver.FindElements(By.CssSelector("div.YgByBe"));
            }
            IWebElement result11 = buttons[6], result12 = buttons[8], result13 = buttons[9];

            result11.Click();
            var lists = driver.FindElements(By.CssSelector("ul.VfPpkd-OJnkse"));
            while (lists.Count < 11)
            {
                lists = driver.FindElements(By.CssSelector("ul.VfPpkd-OJnkse"));
            }
            IWebElement result21 = lists[7], result22 = lists[9], result23 = lists[10];

            foreach (var span in result21.FindElements(By.TagName("li")))
            {
                if (span.GetAttribute("data-value").Equals("nvidia-tesla-v100"))
                {
                    span.Click();
                    break;
                }
            }

            result12.Click();
            foreach (var span in result22.FindElements(By.TagName("li")))
            {
                if (span.GetAttribute("data-value").Equals("2"))
                {
                    span.Click();
                    break;
                }
            }

            result13.Click();
            foreach (var span in result23.FindElements(By.TagName("li")))
            {
                if (span.GetAttribute("data-value").Equals("europe-west4"))
                {
                    span.Click();
                    break;
                }
            }
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
            var text = driver.FindElements(By.CssSelector("span.Kfvdz"));
            Assert.That(text[2].Text, Is.EqualTo("n1-standard-8, vCPUs: 8, RAM: 30 GB"));
            Assert.That(text[4].Text, Is.EqualTo("NVIDIA V100"));
            Assert.That(text[6].Text, Is.EqualTo("2x375 GB"));
            Assert.That(text[10].Text, Is.EqualTo("Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)"));
            Assert.That(text[11].Text, Is.EqualTo("Regular"));
            Assert.That(text[17].Text, Is.EqualTo("Netherlands (europe-west4)"));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}