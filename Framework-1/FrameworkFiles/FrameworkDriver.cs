using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1.FrameworkFiles
{
    public class DriverManager
    {
        private WebDriver driver;
        private IConfiguration _config;
        public DriverManager(IConfiguration config)
        {
            _config = config;
        }

        public WebDriver getDriver()
        {

            if (driver == null)
            {
                string str = _config["TestConfiguration:browser"];
                switch (str)
                {
                    case "chrome":
                        driver = new ChromeDriver();
                        break;
                    default:
                        driver = new FirefoxDriver();
                        break;
                }
            }
            return driver;
        }
        public void closeDriver()
        {
            driver.Dispose();
            driver = null;
        }
    }
}
