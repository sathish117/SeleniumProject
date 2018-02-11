using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BitBucketProject
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CheckLogoExist()
        {
            return _driver.FindElement(By.Id("logo")).Displayed;
        }

    }
}
