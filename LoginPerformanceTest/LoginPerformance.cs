using System;
using System.Diagnostics;
using BitBucketProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace BitBucketProjectTests
{
    [TestClass]
    public class LoginPerformance
    {
        [TestMethod]
        public void FirstTest()
        {
            LoginPage action = new LoginPage();
            action.InitializeDriver();

            action.LaunchWebApplication();

            action.UnCheckKeepMeLoggedIn();
            
            action.EnterUserName();
            action.EnterPassword();

            action.SelectLoginButton();
            Stopwatch watch = Stopwatch.StartNew();

            Assert.IsTrue(action.CheckLogoExist());
            
            watch.Stop();
            action.CloseBrowser();
            long timeElapsed = watch.ElapsedMilliseconds;
            Trace.WriteLine("Time to Login in MilliSeconds:" + timeElapsed);
            Trace.WriteLine("Time of last test run:" + DateTime.Now);
            Assert.IsTrue(watch.ElapsedMilliseconds <= 30000);

            Thread.Sleep(1000);

        }
    }
}
