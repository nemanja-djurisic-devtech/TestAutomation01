using System;
using OpenQA.Selenium;
using Temp_Init.Base;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace Temp_Init.Pages
{
    public class CommonElements : Initialization
    {
        public CommonElements(IWebDriver browser)
        {
            Driver = browser;
            PageFactory.InitElements(browser, this);
        }

        //---------- E L E M E N T S ----------//

        //---------- A C T I O N S ----------//

        //Verify if correct page URL is displayed
        public void VerifyPageUrl(string page)
        {
            Assert.IsTrue(Driver.Url.Equals(page));
        }

        //Get page Url
        public string url;

        public void GetUrl(string replace, string replacement)
        {
            url = Driver.Url.Replace(replace, replacement);
            Console.WriteLine(url);
        }
    }
}
