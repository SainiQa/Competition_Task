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
    public class ProfilePage : Common
    {
        //public ProfilePage()
        //{
        //    PageFactory.InitElements(driver, this);
        //}

        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button' and contains(text(),'Share Skill')]")]
        public IWebElement ShareSkillButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='item' and contains(text(),'Manage Listings']")]
        public IWebElement manageListingsButton { get; set; }

        public void NavigateToShareSkill()
        {
            PageFactory.InitElements(driver, this);
            ShareSkillButton.Click();
            Wait(3);

        }

        public void NavigateToManageListings()
        {
            PageFactory.InitElements(driver, this);
            manageListingsButton.Click();
            Wait(3);
        }
    }
}
