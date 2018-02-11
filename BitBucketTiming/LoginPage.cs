using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BitBucketProject
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private string userID;
        private string password;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static LoginPage LaunchApplication(IWebDriver driver)
        {

            driver.Url = "http://bass-stash.int.elekta.com/login";

            return new LoginPage(driver);
        }

        public String UserID
        {
            set
            {
                _driver.FindElement(By.Id("j_username")).SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                _driver.FindElement(By.Id("j_password")).SendKeys(value);
            }
        }

        public void UnCheckKeepMeLoggedIn()
        {
            if (_driver.FindElement(By.Id("_atl_remember_me")).Selected)
            {
                _driver.FindElement(By.Id("_atl_remember_me")).Click();
            }
        }

        public HomePage SelectLoginButton()
        {
            _driver.FindElement(By.Id("submit")).Submit();
            return new HomePage(_driver);
        }

    }
}
