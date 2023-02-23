using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Task.Utilities
{
    public class Common
    {
        public static IWebDriver driver;
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        public static void ImpliWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public void Close()
        {
            driver.Quit();

        }

    }
}
