using Competition_Task.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competition_Task.ExcelReader;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using ExcelDataReader;



namespace Competition_Task.Pages
{
    public class LoginPage:Common
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='item']")]
        public IWebElement SignInButton { get; set; }
        //public static FileStream stream;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement UserNameTextbox { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement PasswordTextbox { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@class='fluid ui teal button'][text()='Login']")]
        public IWebElement LoginButton { get; set; }

        

        //Login
        public void LoginSteps()
        {
            PageFactory.InitElements(driver, this);

            ExcelUtil.PopulateInCollection(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\Data\SkillShare.xlsx","SignIn");
           

            string Uid = ExcelUtil.ReadData(2, "Username");

            if (Uid == "poojasaini31@gmail.com")
            {
                SignInButton.Click();                

                UserNameTextbox.SendKeys(ExcelUtil.ReadData(2, "Username"));
                PasswordTextbox.SendKeys(ExcelUtil.ReadData(2, "Password"));
               
                LoginButton.Click();
                Thread.Sleep(3000);
                //Wait(5);

            }

            else
            {
                //ExcelUtil.ClearData();
                ExcelUtil.PopulateInCollection(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\Data\SkillShare.xlsx", "SignUp");
                SignupPage signupPageObj = new SignupPage();
                signupPageObj.SignUpSteps();
            }


        }
    }
}
