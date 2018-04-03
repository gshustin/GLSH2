using System;
using OpenQA.Selenium;
using GLSH.Common;
using GLSH.Report;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using static GLSH.Common.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace GLSH.Pages
{
    class FormPage
    {
        private IWebDriver driver;
        public string sUploadPath = Variables.sUserDocFolder + UPLOAD_FILE_NAME;

        cmn Common = new cmn();
        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "Partial")]
        private IWebElement PartialLink { get; set; }

        [FindsBy(How = How.LinkText, Using = "Link Test")]
        private IWebElement Link { get; set; }

        [FindsBy(How = How.Name, Using = "firstname")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "lastname")]
        private IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "datepicker")]
        private IWebElement Date { get; set; }

        [FindsBy(How = How.Id, Using = "profession-0")]
        private IWebElement Profession { get; set; }

        [FindsBy(How = How.Id, Using = "exp-4")]
        private IWebElement Experience { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='photo']")]        
        private IWebElement BtnChooseFile { get; set; }

        [FindsBy(How = How.Id, Using = "continents")]
        private IWebElement Continent { get; set; }

        [FindsBy(How = How.Id, Using = "selenium_commands")]
        private IWebElement Commands { get; set; }

        [FindsBy(How = How.Id, Using = "tool-2")]
        private IWebElement Tool { get; set; }

        public void isElementPresent()
        {
            try
            {
                Assert.IsTrue(Common.waitForElementIsPresent("First name field", "name", "firstname", Constants.TIME_OUT));
            }
            catch (AssertFailedException e)
            {
                ExReports.reportFail("Element is on the page" + e.Message);
                throw;
            }
        }

        public void chooseProfilePicture()
        {
            try
            {
                Common.createFile(sUploadPath);

                BtnChooseFile.Click();
                SendKeys.SendWait(sUploadPath);
                SendKeys.SendWait(@"{Enter}");

                ExReports.reportPass("File '" + UPLOAD_FILE_NAME + "' is uploaded");
            } catch (Exception e)
            {
                ExReports.reportFail("File '" + UPLOAD_FILE_NAME + "' is not uploaded. " + e.Message);
                throw;
            }
        }

        public void selectContinent()
        {
            Continent.SendKeys("Africa");
        }

        public void selectCommands()
        {
            try
            {
                SelectElement oSelect = new SelectElement(Commands);
                oSelect.SelectByText("Navigation Commands");
                oSelect.SelectByText("Wait Commands");
                ExReports.reportPass("Two commands are selected");
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void selectProfessionYearsAndTool()
        {
            try
            {
                Profession.Click();
                Experience.Click();
                Tool.Click();
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void selectSex()
        {
            Common.selectRadioBtn("sex");
        }

        public void pressBack()
        {
            try
            {
                driver.Navigate().Back();
                ExReports.reportPass("'Back' button is clicked");
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void selectLinks()
        {
            try
            {
                PartialLink.Click();
                ExReports.reportPass("Partial Link is clicked");
                Link.Click();
                ExReports.reportPass("Link is clicked");
                Common.checkTextIsPresent("Burj Khalifa");
                ExReports.reportPass("Table page is loaded");
                pressBack();
                Common.checkTextIsPresent("Practice Automation Form");
                ExReports.reportPass("Form page is loaded");
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void fillUserFields()
        {
            try
            {
                FirstName.SendKeys("Gleb");
                ExReports.reportPass("'First name' field is filled");

                LastName.SendKeys("Shustin");
                ExReports.reportPass("'Last name' field is filled");
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void fillDate()
        {
            DateTime today = DateTime.Today;
            Date.SendKeys(today.ToString("dd/MM/yyyy"));
        }
    }
}
