using System;
using System.Diagnostics;
using BitBucketProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace BitBucketProjectTests
{
    [TestClass]
    public class LoginPerformance
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        [TestMethod]
        public void BitBucketLoginPerformance()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            _driver = new ChromeDriver(options);

            _driver.Manage().Window.Maximize();
            //_driver.Manage().Cookies.DeleteAllCookies();

            _loginPage= LoginPage.LaunchApplication(_driver);

            _loginPage.UserID = "usnatsat";
            _loginPage.Password = "dgdsffd";
            
            _loginPage.UnCheckKeepMeLoggedIn();

            _homePage= _loginPage.SelectLoginButton();

            Stopwatch watch = Stopwatch.StartNew();

            Assert.IsTrue(_homePage.CheckLogoExist());
            
            watch.Stop();

            _driver.Quit();

            long timeElapsed = watch.ElapsedMilliseconds;
            Trace.WriteLine("Time to Login in MilliSeconds:" + timeElapsed);
            Trace.WriteLine("Time of last test run:" + DateTime.Now);
            Assert.IsTrue(watch.ElapsedMilliseconds <= 30000);

            Thread.Sleep(1000);

        }
    }
}
