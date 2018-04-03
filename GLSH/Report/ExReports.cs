using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using static GLSH.Common.Constants;
using GLSH.Common;

namespace GLSH.Report
{
    class ExReports
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest logger;
        private static string sReportPath = Variables.sUserDocFolder + FILE_NAME;
        public static ExtentReports getExtent
        {
            get { return extent;  }
        }

        public static ExtentTest getLogger
        {
            get { return logger; }
        }

        public static string getReportPath()
        {
            return sReportPath;
        }
        
        public static void addReport()
        {
            htmlReporter = new ExtentHtmlReporter(getReportPath());
            htmlReporter.Configuration().DocumentTitle = REPORT_TITLE;
            htmlReporter.Configuration().ReportName = REPORT_NAME;
            htmlReporter.Configuration().Theme = Theme.Standard;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo(Variables.sEnvironmentName, Variables.sEnvironmentValue);           
        }

        public static void createTest(string sDescription)
        {
            logger = extent.CreateTest(sDescription);            
        }

        public static void reportPass(string sMessage)
        {
            logger.Pass(sMessage);
        }

        public static void reportFail(string sMessage)
        {
            logger.Fail(sMessage);
        }

        public static void reportInfo(string sMessage)
        {
            logger.Info(sMessage);           
        }
    }
}
