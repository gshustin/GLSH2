using GLSH.Common;
using GLSH.Report;
using System;

namespace GLSH.Pages
{
    class LogInPage
    {
        cmn Common = new cmn();

        public void inputCredentialsAndSubmit(string sUserName, string sPassword)
        {
            try
            {
                fillUserName(sUserName);
                fillPass(sPassword);
                clickSubmitButton();
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void fillUserName(string sUserName)
        {
            try
            {
                Common.fillField("User name", "id", "user_login", sUserName);
            }
            catch (Exception e)
            {
                ExReports.reportFail(e.Message);
                throw;
            }
        }

        public void clearUserName()
        {
            Common.clearField("User name", "id", "user_login");
        }

        public void clearPass()
        {
            Common.clearField("User password", "id", "user_pass");
        }
        public void fillPass(string sPassword)
        {
            Common.fillField("User password", "id", "user_pass", sPassword);
        }

        public void clickSubmitButton()
        {
            Common.clickButton("Log In", "id", "wp-submit");
        }

        public void checkErrorMessage(string sMessage)
        {
            Common.checkMessage("id", "login_error", sMessage);
        }

        public void checkUserNameAndPassAreEmpty()
        {
            Common.checkFieldIsEmpty("Login", "user_login");
            Common.checkFieldIsEmpty("Password", "user_pass");
        }

        public void clearUserNameAndPass()
        {
            clearUserName();
            clearPass();
        }

        public void checkLogoutSuccessful()
        {
            Common.checkMessage("classname", "message", "You are now logged out.");
        }
        
    }
}
