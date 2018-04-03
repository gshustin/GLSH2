using GLSH.Common;
using GLSH.Pages;
using GLSH.Report;
using NUnit.Framework;
using System.Diagnostics;
using static GLSH.Common.Constants;
using static GLSH.Common.Variables;

namespace GLSH.Tests
{
    class StoreTest
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            BaseClass.setBrowser(sBrowserName);
            BaseClass.Init(STORE_URL);            
        }
             
            
        [Test]
        public void Test01()
        {
            ExReports.createTest("Find and purchase item");
            StorePage s = new StorePage(BaseClass.getDriver);
            s.searchItem("iphone");
            s.openItem();
            s.addToCard();
            s.checkOutItem();

            s.mail = "gshustin@gmail.com";
            s.firstName = "Gleb";
            s.lastName = "Shustin";
            s.address = "9041 E Shorewood Dr.";
            s.city = "Seattle";
            s.state = "WA";
            s.county = "USA";
            s.phone = "4255335454";

            s.submitItem();
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
