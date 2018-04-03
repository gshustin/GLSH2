using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using GLSH.Report;

namespace GLSH.Common
{
    class BaseClass
    {       
        private static IWebDriver driver;
        private static string sBrowser;
        
        public static void setBrowser(string sBrowserName)
        {
            sBrowser = sBrowserName;
        }

        public static IWebDriver getDriver
        {
            get { return driver; }
        }

        public static void goToURL(string sURL)
        {
            driver.Navigate().GoToUrl(sURL);
        }

        public static void Init(string sURL)
        {            
            switch (sBrowser)
            {
                case "Firefox":                    
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    ChromeOptions option = new ChromeOptions();
                    option.AddArguments("disable-infobars");
                    driver = new ChromeDriver(option);
                    break;                
            }
            ExReports.addReport();

            driver.Manage().Window.Maximize();
            goToURL(sURL);
        }

        public static void Close()
        {
            driver.Quit();
            driver = null;
            ExReports.getExtent.Flush();            
        }
    }
}
