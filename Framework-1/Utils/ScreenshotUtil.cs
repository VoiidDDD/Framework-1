using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Framework_1.FrameworkFiles
{
    public class ScreenshotUtil
    {
        public static void takeScreenshot(WebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                
            string screenshotDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Screenshots\\";
            Directory.CreateDirectory(screenshotDirectory);
            string screenshotPath = Path.Combine(screenshotDirectory, $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);

            Console.WriteLine($"Screenshot saved: {screenshotPath}");
        }
    }
}
