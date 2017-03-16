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

        //Save button
        [FindsBy(How = How.Id, Using = "Save")]
        public IWebElement SaveBtn { get; set; }

        //Save button
        [FindsBy(How = How.ClassName, Using = "user-name")]
        public IWebElement UserName { get; set; }

        //Save button
        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        //Login button - MULTIPLE LOCATORS
        [FindsBy(How = How.XPath, Using = "//label[@for='login' and div[@class='on']]")]
        public IWebElement LoginBtn { get; set; }

        //Page header
        [FindsBy(How = How.CssSelector, Using = ".header.login-panel")]
        public IWebElement Header { get; set; }


        //---------- A C T I O N S ----------//

        //Login to Web Page
        public void LoginAsCustomer(string userName, string password)
        {
            UserName.Clear();
            UserName.SendKeys(userName);
            Password.Clear();
            Password.SendKeys(password);
            LoginBtn.Click();
        }

        //Verify Loged Customer
        public void VerifyHeader(string text)
        {
            Assert.IsTrue(Header.Text.Contains(text), "Customer is NOT logged in");
        }

        //Compare two values
        public void CompareValues(string value1, string value2)
        {
            Assert.IsTrue(value1.Equals(value2));
            Console.WriteLine(value1);
            Console.WriteLine(value2);
        }

        public void ClearUrl()
        {
            Driver.Url.Remove(1, 30);
        }

        //Confirm Pop-up
        public void AcceptDialog()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }

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
