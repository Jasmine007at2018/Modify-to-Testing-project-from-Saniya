using GrabOne_J.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using RelevantCodes.ExtentReports;
using NUnit.Framework;
using static GrabOne_J.Global.CommonMethods;

namespace GrabOne_J.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(ResourceForGrabOne.Browser);
        public static String ExcelPath = ResourceForGrabOne.ExcelPath;
        public static string ScreenshotPath = ResourceForGrabOne.ScreenShotPath;
        public static string ReportPath = ResourceForGrabOne.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    Driver.driver = new ChromeDriver();
                    break;
                case 2:
                    Driver.driver = new FirefoxDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;

            }
            //if (Keys_Resource.IsLogin == "true")
            //{
            //    Login loginobj = new Login();
            //    loginobj.LoginSuccessfull();
            //}
            //else
            //{
            //    Register obj = new Register();
            //    obj.Navigateregister();
            //}

            Actions action = new Actions(Global.Driver.driver);
            action.SendKeys(Keys.Escape).Build().Perform();
            Thread.Sleep(2000);

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(ResourceForGrabOne.ReportXMLPath);
        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            Driver.driver.Close();
        }
        #endregion
    }
}
