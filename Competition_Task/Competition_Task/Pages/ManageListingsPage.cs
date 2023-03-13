using Competition_Task.ExcelReader;
using Competition_Task.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Task.Pages
{
    public class ManageListingsPage:Common
    {
        

        [FindsBy(How = How.XPath, Using = "//section[@class='nav-secondary']/div[@class='ui eight item menu']/a[@href='/Home/ListingManagement']")]

        public IWebElement manageListingTab;

        [FindsBy(How = How.XPath, Using = "//table[@class='ui striped table']/tbody/tr[1]/td[8]/div[@class='ui small icon buttons basic vertical']/button[2]/i[@class='outline write icon']")]
        
        public IWebElement editIcon;
       
        [FindsBy(How = How.XPath, Using = "//table[@class='ui striped table']/tbody/tr[1]/td[8]/div[@class='ui small icon buttons basic vertical']/button[3]/i[@class='remove icon']")]
        public IWebElement deleteIcon;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        public IWebElement deleteConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='ui striped table']/tbody/tr[1]/td[3]")]
        
        public IWebElement titleValidate;           


        public void NavigateToEdit()
        {
            PageFactory.InitElements(driver, this);
            manageListingTab.Click();
            Thread.Sleep(5000);
            editIcon.Click();
            Wait(3);           

        }
    public string GetCreateDelete()
        {
           PageFactory.InitElements(driver, this);
            
            manageListingTab.Click();
            Thread.Sleep(2000);
            string DeletedTitleText = titleValidate.Text;
            return DeletedTitleText;
        }

        public void DeleteSkills()
        {            
            PageFactory.InitElements(driver, this);
            manageListingTab.Click();
            Thread.Sleep(3000);
            deleteIcon.Click();
            //driver.SwitchTo().Alert().Accept();
            deleteConfirm.Click();
            Wait(3);               


        }
        public string DeleteTitletocompare()
        {
            PageFactory.InitElements(driver, this);
            ExcelUtil.PopulateInCollection(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\Data\SkillShare.xlsx", "ShareSkill");

            string TitlefromExcel = ExcelUtil.ReadData(3, "Title");
            return TitlefromExcel;
        }

    }
    }



