using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Competition_Task.ExcelReader;
using Competition_Task.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Competition_Task.Utilities
{
    public class Common
    {     
        public static IWebDriver driver;
        //LoginPage loginPageObj;
         SignupPage signupPageObj;

        public static ExtentReports extentReportObj = null;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;
        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName +
        Path.DirectorySeparatorChar + "ExtentReports" +
        Path.DirectorySeparatorChar + "Result " + DateTime.Now.ToString("ddMMyyyy HHmmss");

        [OneTimeSetUp]
        public void LoginActions()
        {

            //htmlReporter = new ExtentHtmlReporter(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\ExtentReports\SkillShare.html");

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReportObj = new ExtentReports();
            extentReportObj.AttachReporter(htmlReporter);

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();

            
        }

        public static void Wait(int second)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(second);
        }


        public class GetScreenShot
        {
            public static string Capture(IWebDriver driver, string screenShotName)
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().Location;
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Screenshots\\" + screenShotName + ".png";
                string localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
                return localpath;
            }
        }



        [OneTimeTearDown]
        public void Close()
        {           

            extentReportObj.Flush();
            driver.Quit();

        }

    }
}
