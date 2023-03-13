using Competition_Task.ExcelReader;
using Competition_Task.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Task.Pages
{
    public class SignupPage : Common
    {
        
        [FindsBy(How = How.XPath, Using = "//button[@class ='ui green basic button']")]
        public IWebElement joinButton;


        [FindsBy(How = How.Name, Using = "firstName")]
        public IWebElement firstNameTextbox;

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement lastNameTextbox;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement emailTextbox;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement passwordTextbox;

        [FindsBy(How = How.Name, Using = "confirmPassword")]
        public IWebElement confirmPasswordTextbox;

        [FindsBy(How = How.Name, Using = "terms")]
        public IWebElement agreeTerms;

        [FindsBy(How = How.Id, Using = "submit-btn")]
        public IWebElement submitButton;

        


        public void SignUpSteps()
            {
            Thread.Sleep(5000);
            PageFactory.InitElements(driver, this);
            ExcelUtil.PopulateInCollection(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\Data\SkillShare.xlsx", "SignUp");

            joinButton.Click();
            firstNameTextbox.Click();
            firstNameTextbox.SendKeys(ExcelUtil.ReadData(2, "FirstName"));
            lastNameTextbox.Click();    
            lastNameTextbox.SendKeys(ExcelUtil.ReadData(2, "LastName"));

            emailTextbox.Click();
            emailTextbox.SendKeys(ExcelUtil.ReadData(2, "Email"));

            passwordTextbox.Click();
            passwordTextbox.SendKeys(ExcelUtil.ReadData(2, "Password"));

            confirmPasswordTextbox.Click();
            confirmPasswordTextbox.SendKeys(ExcelUtil.ReadData(2, "ConfirmPassword"));

            agreeTerms.Click();
            submitButton.Click();

            
        }

    }
}
