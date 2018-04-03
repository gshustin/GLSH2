using System;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using GLSH.Report;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GLSH.Common
{
    class cmn : BaseClass
    {
        public void clickButton(string sButtonName, string sType, string sObjectLocator)
        {
            try
            {
                waitForElementIsPresent(sButtonName, Constants.TIME_OUT, sObjectLocator);
                switch (sType)
                {
                    case "id":
                        getDriver.FindElement(By.Id(sObjectLocator)).Click();
                        break;
                    case "xpath":
                        getDriver.FindElement(By.XPath(sObjectLocator)).Click();
                        break;
                    case "name":
                        getDriver.FindElement(By.Name(sObjectLocator)).Click();
                        break;
                    case "classname":
                        getDriver.FindElement(By.ClassName(sObjectLocator)).Click();
                        break;
                    case "tagname":
                        getDriver.FindElement(By.TagName(sObjectLocator)).Click();
                        break;
                }
                ExReports.reportPass("Button '" + sButtonName + "' is clicked");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Button '" + sButtonName + "' is not clicked. " + e.Message);
                throw;
            }
        }

        public void checkElementIsDisplayed(string sName, string sObjectLocator)
        {
            try
            {
                waitForElementIsPresent(sName, Constants.TIME_OUT, sObjectLocator);
                Assert.IsTrue(getDriver.FindElement(By.Id(sObjectLocator)).Displayed);
                ExReports.reportPass("Element '" + sName + "' is displayed");
            }
            catch (AssertFailedException e)
            {
                ExReports.reportFail("Element '" + sName + "' is not displayed. " + e.Message);
                throw;
            }
        }
   
        public void checkMessage(string sType, string sObjectLocator, string sMessage)
        {
            try
            {
                switch (sType)
                {
                    case "id":
                        waitForElementIsPresent(sMessage, Constants.TIME_OUT, sObjectLocator);
                        Assert.AreEqual(getDriver.FindElement(By.Id(sObjectLocator)).Text, sMessage);
                        ExReports.reportInfo("Message '" + sMessage + "' is checked");
                        break;
                }
            }
            catch (AssertFailedException e)
            {
                ExReports.reportFail("Message '" + sMessage + "' is not checked. " + e.Message);
                throw;
            }
        }

        public void checkFieldValue(string sObjectLocator, string sValue)
        {
            try
            {
                waitForElementIsPresent(sValue, Constants.TIME_OUT, sObjectLocator);
                Assert.AreEqual(getDriver.FindElement(By.Id(sObjectLocator)).GetAttribute("value"), sValue);
                ExReports.reportPass("Check field - Value '" + sValue + "' is correct");
            }
            catch (AssertFailedException)
            {
                ExReports.reportFail("Check field - Value '" + sValue + "' is not correct");
                throw;
            }
        }

       public void checkFieldIsEmpty(string sName, string sObjectLocator)
        {
            try
            {
                waitForElementIsPresent(sName, Constants.TIME_OUT, sObjectLocator);
                Assert.IsTrue(String.IsNullOrEmpty(getDriver.FindElement(By.Id(sObjectLocator)).GetAttribute("value")));
                ExReports.reportPass("Field '" + sName + "' is empty");
            } catch (AssertFailedException)
            {
                ExReports.reportFail("Field '" + sName + "' is not empty");
                throw;
            }
        }

        public void fillField(string sFieldName, string sType, string sObjectLocator, string sData)
        {
            try
            {
                switch (sType)
                {
                    case "id":
                        waitForElementIsPresent(sFieldName, Constants.TIME_OUT, sObjectLocator);
                        getDriver.FindElement(By.Id(sObjectLocator)).SendKeys(sData);
                        ExReports.reportPass("Field '" + sFieldName + "' is filled");
                        break;
                    case "name":
                        getDriver.FindElement(By.Name(sObjectLocator)).SendKeys(sData);
                        break;
                }
            }
            catch (Exception e)
            {
                ExReports.reportFail("Field '" + sFieldName + "' is not filled. " + e.Message);
                throw;
            }
        }

        public void clearField(string sFieldName, string sType, string sObjectLocator)
        {
            try
            {
                waitForElementIsPresent(sFieldName, Constants.TIME_OUT, sObjectLocator);
                switch (sType)
                {
                    case "id":
                        getDriver.FindElement(By.Id(sObjectLocator)).Clear();
                        break;
                    case "name":
                        getDriver.FindElement(By.Name(sObjectLocator)).Clear();
                        break;
                }
                ExReports.reportPass("Clear field - Field '" + sFieldName + "' is cleared");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Field '" + sFieldName + "' is not cleared. " + e.Message);
                throw;
            }
        }

        public void clickPartialLink(string sLinkText)
        {
            getDriver.FindElement(By.PartialLinkText(sLinkText)).Click();
            ExReports.reportPass("Link is selected");            
        }

        public void clickLink(string sLink)
        {
            try
            {
                getDriver.FindElement(By.LinkText(sLink)).Click();
                ExReports.reportPass("Link is selected");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Link is not clicked. " + e.Message);
                throw;
            }
        }
       
        public void selectRadioBtn(string sName)
        {
            try
            {
                IList<IWebElement> oRadioButton = getDriver.FindElements(By.Name(sName));

                bool bValue = false;
                bValue = oRadioButton.ElementAt(0).Selected;
                if (bValue == true)
                {
                    oRadioButton.ElementAt(1).Click();
                }
                else
                {
                    oRadioButton.ElementAt(0).Click();
                }
            }
            catch (Exception e)
            {
                ExReports.reportFail("Radiobutton is not selected. " + e.Message);
                throw;
            }
        }

        public void createFile(string sFileName)
        {
            try
            { 
                if (File.Exists(sFileName))
                {
                    File.Delete(sFileName);
                }

                File.Create(sFileName);
            }
            catch (Exception e)
            {
                ExReports.reportFail("File is not created. " + e.Message);
            }
        }

        public void checkTextIsPresent(string sText)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(getDriver, TimeSpan.FromSeconds(Constants.TIME_OUT));
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(String.Format("//*[contains(text(), '" + sText + "')]")))));
                ExReports.reportPass("Text '" + sText + "' is found on page");
            }
            catch (WebDriverTimeoutException)
            {
                ExReports.reportFail("Text '" + sText + "' is not found on page");
                throw;
            }
        }


        /// <Wait methods>
        public void waitForElementIsPresent(string sName, int iTimeOut, string sObjectLocator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(getDriver, TimeSpan.FromSeconds(iTimeOut));
                wait.Until(ExpectedConditions.ElementIsVisible((By.Id(sObjectLocator))));
                ExReports.reportInfo("Element '" + sName + "' is found");
            } catch (WebDriverTimeoutException)
            { 
                ExReports.reportFail("Timeout is over - Element '" + sName + "' is not found");
                throw;
            }           
        }
        
        public bool waitForElementIsPresent(string sName, string sType, string sObjectLocator, int iTimeOut)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(getDriver, TimeSpan.FromSeconds(iTimeOut));
                switch (sType)
                {
                    case "id":
                        wait.Until(ExpectedConditions.ElementIsVisible((By.Id(sObjectLocator))));                        
                        ExReports.reportInfo("Element '" + sName + "' is found");
                        return true;                       
                    case "name":
                        wait.Until(ExpectedConditions.ElementIsVisible((By.Name(sObjectLocator))));
                        ExReports.reportPass("Element '" + sName + "' is found");
                        return true;
                    case "xpath":
                        wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(sObjectLocator))));
                        ExReports.reportPass("Element '" + sName + "' is found");
                        return true;
                    case "link":
                        wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(sObjectLocator)));
                        ExReports.reportPass("Element '" + sName + "' is found");
                        return true;
                }               
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                ExReports.reportFail("Timeout is over - Element '" + sName + "' is not found");
                throw;
            }
        }

        public void waitForMilSec(int milsec)
        {
            Thread.Sleep(milsec);
        }        
    }
}
