using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1.FrameworkFiles
{
    public class ComputeEnginePage
    {
        public static void inputData(WebDriver driver , ComputeEngineConfiguration engineConfig)
        {
            var add = driver.FindElements(By.CssSelector("button.wX4xVc-Bz112c-LgbsSe "))[1];
            for (int i = 0; i < engineConfig.Instances; i++)
            {
                add.Click();
            }
            driver.FindElements(By.CssSelector("div.VfPpkd-O1htCb-OWXEXe-ztc6md"))[3].Click();

            foreach (var item in driver.FindElements(By.CssSelector("ul.VfPpkd-rymPhb"))[6].FindElements(By.TagName("li")))
            {
                if (item.GetAttribute("data-value").Equals(engineConfig.MachineType))
                {
                    item.Click();
                }
            }

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
                if (span.GetAttribute("data-value").Equals(engineConfig.GpuType))
                {
                    span.Click();
                    break;
                }
            }

            result12.Click();
            foreach (var span in result22.FindElements(By.TagName("li")))
            {
                if (span.GetAttribute("data-value").Equals(engineConfig.SsdSize))
                {
                    span.Click();
                    break;
                }
            }

            result13.Click();
            foreach (var span in result23.FindElements(By.TagName("li")))
            {
                if (span.GetAttribute("data-value").Equals(engineConfig.Region))
                {
                    span.Click();
                    break;
                }
            }
        }
    }
}
