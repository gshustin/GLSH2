using NUnit.Framework;
using GLSH.Common;
using GLSH.Pages;
using GLSH.Report;
using static GLSH.Common.Constants;
using System.Diagnostics;

namespace GLSH.Tests
{
    class LogInTestt
    {       
        LogInPage lp = new LogInPage();
        cmn Common = new cmn();
        ProfilePage Profile = new ProfilePage();
        

        [OneTimeSetUp]   
        public void Initialize()
        {
            BaseClass.setBrowser(Variables.sBrowserName);
            BaseClass.Init(LOGIN_URL);
        }


        [Test]
        public void Test01() 
        {
            ExReports.createTest("Login with invalid UserName and Pass");
            lp.clearUserNameAndPass();
            lp.inputCredentialsAndSubmit(INVALID_LOGON, INVALID_PASS);
            lp.checkErrorMessage(AUTORIZATION_ERROR_MESSAGE);
            lp.checkUserNameAndPassAreEmpty();                                 
        }

        [Test]
        public void Test02()
        {
            ExReports.createTest("Login with UserName only");
            lp.clearUserNameAndPass();
            lp.fillUserName(USER_NAME);
            lp.clickSubmitButton();
            lp.checkErrorMessage("ERROR: The password field is empty.");
            Common.checkFieldValue("user_login", USER_NAME);
            Common.checkFieldIsEmpty("Password", "user_pass");
        }

        [Test]
        public void Test03()
        {
            ExReports.createTest("Login with Password only");
            lp.clearUserNameAndPass();
            lp.fillPass(PASS);            
            lp.clickSubmitButton();
            lp.checkErrorMessage("ERROR: The username field is empty.");
            lp.checkUserNameAndPassAreEmpty();
        }

        [Test]
        public void Test04()
        {
            ExReports.createTest("Login with valid credentials");
            lp.clearUserNameAndPass();
            lp.inputCredentialsAndSubmit(USER_NAME, PASS);
            Profile.goToStore();
            Common.checkElementIsDisplayed("Logo", "logo");
            ExReports.reportPass("Login is successful");
        }

        [Test]

        public void Test05()
        {
            ExReports.createTest("Automation Practice Form");
            FormPage f = new FormPage(BaseClass.getDriver);
            BaseClass.goToURL(FORM_URL);

            f.isElementPresent();
            f.selectLinks();
            f.fillUserFields();
            f.fillDate();
            f.selectSex();
            f.selectProfessionYearsAndTool();
            f.selectContinent();
            f.selectCommands();
        }

        [TearDown]
        public void TearDown()
        {
            ExReports.reportInfo("Test was finished");            
        }

        [OneTimeTearDown]
        public void Finish()
        {
            BaseClass.Close();
            Process.Start(ExReports.getReportPath());
        }  
    }
}
