using Competition_Task.ExcelReader;
using Competition_Task.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;




namespace Competition_Task.Pages
{
    public class ShareSkillPage : Common
    {

        

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement titleTextbox { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        //[FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")]
            public IWebElement descriptionTextbox { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        public IWebElement categoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public IWebElement subCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        public IWebElement tags { get; set; }

  
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span/a")]
        public IWebElement tagDeleteIcon { get; set; }
        

        //Select the Service type
        [FindsBy(How = How.XPath, Using = " //div[@class='ui radio checkbox']/input[@name = 'serviceType' and @value=0]")]
        public IWebElement serviceTypeOption1 { get; set; }

        [FindsBy(How = How.XPath, Using = " //div[@class='ui radio checkbox']/input[@name = 'serviceType' and @value=0]")]
        public IWebElement serviceTypeOption2 { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//div[@class='ui radio checkbox']/input[@name = 'locationType' and @value=0]")]
        public IWebElement locationTypeOption1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='ui radio checkbox']/input[@name = 'locationType' and @value=1]")]
        public IWebElement locationTypeOption2 { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        public IWebElement startDate { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        public IWebElement endDate { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//div[@class='ui checkbox']/input[@index='1' and @name='Available']")]
        public IWebElement days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[@class='four wide field']/input[@index='1' and @name='StartTime']")]
        public IWebElement startTime { get; set; }
        

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class='four wide field']/input[@index='1' and @name='EndTime']")]
        public IWebElement endTime { get; set; }        

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='inline fields']/div[1]/div[@class='ui radio checkbox']/input[@name='skillTrades']")]
        public IWebElement skillExchange { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inline fields']/div[2]/div[@class='ui radio checkbox']/input[@name='skillTrades']")]
        public IWebElement credit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        public IWebElement skillExchangeTag { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        public IWebElement creditAmount { get; set; }

        //click on worksample button
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        public IWebElement workSample { get; set; }               

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = " //div[@class ='ui radio checkbox']/input[@name='isActive' and @tabindex='0']")]
        public IWebElement activeOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement save { get; set; }

        [FindsBy(How = How.XPath, Using = "//section[@class='nav-secondary']/div[@class='ui eight item menu']/a[@href='/Home/ListingManagement']")]
        public IWebElement manageListingTab;
               


        //Method to Create Skills
        public void Create_Skills()
        {
            PageFactory.InitElements(driver, this);

            ExcelUtil.PopulateInCollection(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\Data\SkillShare.xlsx", "ShareSkill");

          
            titleTextbox.Click();
            titleTextbox.SendKeys(ExcelUtil.ReadData(2, "Title"));
                     

            descriptionTextbox.Click();
            descriptionTextbox.SendKeys(ExcelUtil.ReadData(2, "Description"));


            categoryDropDown.Click();
            SelectElement selectCategory = new SelectElement(categoryDropDown);
            selectCategory.SelectByText(ExcelUtil.ReadData(2, "Category"));

            SelectElement selectSubcategory = new SelectElement(subCategoryDropDown);
            selectSubcategory.SelectByText(ExcelUtil.ReadData(2, "Subcategory"));

            tags.Click();
            tags.SendKeys(ExcelUtil.ReadData(2, "Tag1"));
            tags.SendKeys(Keys.Return);

            tags.Click();
            tags.SendKeys(ExcelUtil.ReadData(2, "Tag2"));
            tags.SendKeys(Keys.Return);

            String H = ExcelUtil.ReadData(2, "ServiceType");
            if (H == "Hourly basis service")
            {
                serviceTypeOption1.Click();
            }
            else
            {
                serviceTypeOption2.Click();
            }
            String L = ExcelUtil.ReadData(2, "LocationType");
            if (L == "Online")
            {
                locationTypeOption2.Click();
            }
            else
            {
                locationTypeOption1.Click();
            }
                        
            startDate.SendKeys(ExcelUtil.ReadData(2, "StartDate"));
            endDate.SendKeys(ExcelUtil.ReadData(2, "EndDate"));
                      

            days.Click();

            startTime.SendKeys(ExcelUtil.ReadData(2, "StartTime"));
            endTime.SendKeys(ExcelUtil.ReadData(2, "EndTime"));            

            skillExchange.Click();

            skillExchangeTag.Click();
            skillExchangeTag.SendKeys(ExcelUtil.ReadData(2, "SkillExchangeTag"));
            skillExchangeTag.SendKeys(Keys.Return);

            workSample.Click();
            Thread.Sleep(2000);
            using (Process exeProcess = Process.Start(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\AutoIt\MyAutoItScript.exe"))
            {
                exeProcess.WaitForExit();
            }
            
            activeOption.Click();
            save.Click();
            Wait(5);

            

        }

        //Method to Get the title for just created skill
        public string GetTitle()
        {
            PageFactory.InitElements(driver, this);

            string TitlefromExcel= (ExcelUtil.ReadData(2, "Title"));
            return TitlefromExcel;
        }

        //Method to Edit the Skills
        public void Edit_Skills()
        {
            PageFactory.InitElements(driver, this);
            Wait(3);
            
            ExcelUtil.PopulateInCollection(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\Data\SkillShare.xlsx", "ShareSkill");
            Wait(3);
            Thread.Sleep(6000);
            titleTextbox.Click();
            titleTextbox.Clear ();
            titleTextbox.SendKeys(ExcelUtil.ReadData(3, "Title"));

            descriptionTextbox.Click();
            descriptionTextbox.Clear ();
            descriptionTextbox.SendKeys(ExcelUtil.ReadData(3, "Description"));

            categoryDropDown.Click();
            SelectElement selectCategory = new SelectElement(categoryDropDown);
            selectCategory.SelectByText(ExcelUtil.ReadData(3, "Category"));

            SelectElement selectSubcategory = new SelectElement(subCategoryDropDown);
            selectSubcategory.SelectByText(ExcelUtil.ReadData(3, "Subcategory"));

            tagDeleteIcon.Click();
            tags.Click();
            tags.SendKeys(ExcelUtil.ReadData(3, "Tag1"));
            tags.SendKeys(Keys.Return);
           
            String H1 = ExcelUtil.ReadData(2, "ServiceType");
            if (H1 == "Hourly basis service")
            {
                serviceTypeOption1.Click();
            }
            else
            {
                serviceTypeOption2.Click();
            }
            String L1 = ExcelUtil.ReadData(2, "LocationType");
            if (L1 == "Online")
            {
                locationTypeOption2.Click();
            }
            else
            {
                locationTypeOption1.Click();
            }

            startDate.SendKeys(ExcelUtil.ReadData(3, "StartDate"));
            endDate.SendKeys(ExcelUtil.ReadData(3, "EndDate"));
            
            days.Click();

            startTime.SendKeys(ExcelUtil.ReadData(3, "StartTime"));
            endTime.SendKeys(ExcelUtil.ReadData(3, "EndTime"));            

            credit.Click();
            creditAmount.Click();
            creditAmount.SendKeys(ExcelUtil.ReadData(3, "Credit"));            

            workSample.Click();
            Thread.Sleep(2000);
            using (Process exeProcess = Process.Start(@"D:\Competition_Task\Competition_Task\Competition_Task\Competition_Task\AutoIt\MyAutoItScript.exe"))
            {
              exeProcess.WaitForExit();
            }

            activeOption.Click();
            save.Click();
            
        }

        public string EditedGetTitle()
        {
            PageFactory.InitElements(driver, this);
            string editedTitlefromExcel = ExcelUtil.ReadData(3, "Title");
            return editedTitlefromExcel;
        }

    }
}

