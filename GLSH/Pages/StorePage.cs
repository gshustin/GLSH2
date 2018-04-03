using OpenQA.Selenium;
using System;
using GLSH.Common;
using GLSH.Report;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace GLSH.Pages
{
    class StorePage
    {
        private IWebDriver driver;
        cmn Common = new cmn();
        public StorePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "account_logout")]
        private IWebElement BtnLogOut { get; set; }

        [FindsBy(How = How.Name, Using = "s")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='iPhone 5']")]
        private IWebElement lnkItem { get; set; }

        [FindsBy(How = How.Id, Using = "header_cart")]
        private IWebElement BtnCount { get; set; }

        //[FindsBy(How = How.ClassName, Using = "step2")]
        //private IWebElement BtnContinue { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Continue')]")]

        //driver.FindElement(By.XPath("//span[contains(.,'Continue')]"));
        private IWebElement BtnContinue { get; set; }

        [FindsBy(How = How.ClassName, Using = "wpsc_buy_button")]
        private IWebElement BtnAddToCard { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='wpsc_checkout_form_2']")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='wpsc_checkout_form_3']")]
        private IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[@data-wpsc-meta-key='billingaddress']")]
        private IWebElement Address { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_5")]
        private IWebElement City { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_6")]
        private IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_7")]
        private IWebElement Country { get; set; }
        
        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_18")]
        private IWebElement Phone { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_9")]
        private IWebElement EMail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Purchase')]")]
        private IWebElement BtnSubmit { get; set; }

        [FindsBy(How = How.ClassName, Using = "count")]
        private IWebElement Count { get; set; }

        [FindsBy(How = How.Id, Using = "logo")]
        private IWebElement Logo { get; set; }

        public string getCount
        {
            get { return Count.Text; }
        }

        public void searchItem(string sItemName)
        {
            try
            {
                Common.waitForElementIsPresent("Search", "name", "s", Constants.TIME_OUT);
                SearchField.SendKeys(sItemName);
                ExReports.reportPass("'Search' field is filled");
                SearchField.SendKeys(Keys.Enter);
                ExReports.reportPass("'Enter' is pressed");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Search item" + e.Message);
                throw;
            }
        }
        
        public void openItem()
        {
            try
            {
                Common.waitForElementIsPresent("Item link", "xpath", "//*[text()='iPhone 5']", Constants.TIME_OUT);
                lnkItem.Click();
                ExReports.reportPass("'Item link' is selected");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Open item" + e.Message);
                throw;
            }
        }

        public void addToCard()
        {
            try
            {
                Common.waitForElementIsPresent("Add to Card button", "classname", "wpsc_buy_button", Constants.TIME_OUT);
                BtnAddToCard.Click();
                ExReports.reportPass("Button 'Add to card' is clicked");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Add to card" + e.Message);
                throw;
            }
        }

        public void checkOutItem()
        {
            try
            {
                Common.waitForElementIsPresent("Check out", "id", "header_cart", Constants.TIME_OUT);
                BtnCount.Click();
                ExReports.reportPass("'Check out' is clicked");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.TIME_OUT));
                wait.Until(ExpectedConditions.TextToBePresentInElement(Count, getCount));
                ExReports.reportPass("1 item is on the card");

                //Common.waitForElementIsPresent("Continue button", "classname", "step2", Constants.TIME_OUT);
                Common.waitForElementIsPresent("Continue button", "xpath", "//span[contains(.,'Continue')]", Constants.TIME_OUT);
                BtnContinue.Click();
                ExReports.reportPass("'Continue' button is clicked");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Check out item" + e.Message);
                throw;
            }
        }

        public string mail
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    EMail.SendKeys(value);
                    ExReports.reportPass("'Email' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'Email' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string firstName
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    FirstName.SendKeys(value);
                    ExReports.reportPass("'First Name' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'First Name' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string lastName
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    LastName.SendKeys(value);
                    ExReports.reportPass("'Last Name' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'Last Name' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string address
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    Address.SendKeys(value);
                    ExReports.reportPass("'Address' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'Address' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string city
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    City.SendKeys(value);
                    ExReports.reportPass("'City' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'City' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string state
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    State.SendKeys(value);
                    ExReports.reportPass("'State' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'State' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string county
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    Country.SendKeys(value);
                    ExReports.reportPass("'Country' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'Country' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public string phone
        {
            set
            {
                try
                {
                    Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                    Phone.SendKeys(value);
                    ExReports.reportPass("'Phone' field is filled");
                }
                catch (Exception e)
                {
                    ExReports.reportFail("'Phone' field is not filled " + e.Message);
                    throw;
                }
            }
        }

        public void submitItem()
        {
            try
            {
                Common.waitForElementIsPresent("First name field", "xpath", "//input[@id='wpsc_checkout_form_2']", Constants.TIME_OUT);
                BtnSubmit.Click();
                ExReports.reportPass("'Purchase' button is clicked");

                Common.checkTextIsPresent("Thank you, your purchase is pending");
            }
            catch (Exception e)
            {
                ExReports.reportFail("Submit Item error" + e.Message);
                throw;
            }
        }
    }
}
