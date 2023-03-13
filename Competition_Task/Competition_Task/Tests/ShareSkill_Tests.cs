using AventStack.ExtentReports;
using Competition_Task.ExcelReader;
using Competition_Task.Pages;
using Competition_Task.Utilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static Competition_Task.Utilities.Common;


namespace Competition_Task.Tests
{
    [TestFixture]
    public class ShareSkill_Tests : Common
    {
        ProfilePage profilePageObj;
        ManageListingsPage manageListingsPageObj;
        ShareSkillPage shareSkillPageObj;
        String createdTitle;
        string createdTitleFromListings;
        string editedTitle;
        string editedTitleFromListings;
        string screenShotPath;
        public ShareSkill_Tests()
        {   
          profilePageObj = new ProfilePage();
          manageListingsPageObj = new ManageListingsPage();
          shareSkillPageObj = new ShareSkillPage();
         
        }


        [Test, Order(1)]
        public void Create_Skills_Test()
        {         
            profilePageObj.NavigateToShareSkill();
            shareSkillPageObj.Create_Skills();                       

            //Validation for Create Skill
            createdTitle = shareSkillPageObj.GetTitle();
            createdTitleFromListings = manageListingsPageObj.GetCreateDelete();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            
            if (editedTitle == editedTitleFromListings)
            {
                test = extentReportObj.CreateTest("Create Skill", " Create new Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is created successfully");
                test.Log(Status.Pass, "Test passed");

                Assert.Pass("Skill record is Created successfully");
            }
            else
            {
                test = extentReportObj.CreateTest("Create Skill", " Create new Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skills Not created");
                test.Log(Status.Pass, "Test Failed");
                Assert.Fail("Skill record is Not Edited");

            }        

        }

        [Test, Order(2)]
        public void Edit_Skills_test()
        {
            //test = extentReportObj.CreateTest("Edit Skills", " Edit the already created Skills");
            

            manageListingsPageObj.NavigateToEdit();
            shareSkillPageObj.Edit_Skills();

            editedTitle = shareSkillPageObj.EditedGetTitle();
            editedTitleFromListings = manageListingsPageObj.GetCreateDelete();
            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            if (editedTitle == editedTitleFromListings)
            {
                test = extentReportObj.CreateTest("Edit Skill", " Edit the existing Skill").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is Edited successfully");
                test.Log(Status.Pass, "Test passed");

                Assert.Pass("Skill record is edited successfully");                
            }
            else
            {
                test = extentReportObj.CreateTest("Create Skill", " Create new Skills").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skills not edited ");
                test.Log(Status.Pass, "Test failed");

                Assert.Fail("Skill record is Not Edited");
                
            }           
            

        }

        [Test, Order(3)]
        public void Delete_Skills_Test()
        {
            //screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            manageListingsPageObj.DeleteSkills();
            

            string titleinlistings = manageListingsPageObj.GetCreateDelete();
            //string titleTobeDeleted = shareSkillPageObj.EditedGetTitle();
            string titleTobeDeleted = manageListingsPageObj.DeleteTitletocompare();


            Console.WriteLine(titleinlistings);
            Console.WriteLine(titleTobeDeleted);


            screenShotPath = GetScreenShot.Capture(driver, "ScreenShotName");

            if (titleinlistings != titleTobeDeleted)
            {
                test = extentReportObj.CreateTest("Delete Skill", " Delete Skill record").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill record is Deleted successfully");
                test.Log(Status.Pass, "Test passed");
                Assert.Pass("Skill record is Deleted successfully");
            }
            else
            {
                test = extentReportObj.CreateTest("Delete Skill", " Delete Skill record").AddScreenCaptureFromPath(screenShotPath);
                test.Log(Status.Info, "Skill NOT deleted");
                test.Log(Status.Pass, "Test Failed");
                Assert.Fail("Skill record is Not deleted");
            }


        }

        
    }    
}
       


