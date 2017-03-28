using System;
using System.Threading;
using OpenQA.Selenium;
using Temp_Init.Base;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace Temp_Init.Pages
{
    public class WebPage1 : Initialization
    {
        public WebPage1(IWebDriver browser)
        {
            Driver = browser;
            PageFactory.InitElements(browser, this);
        }

        //---------- E L E M E N T S ----------//

        //Test Text
        [FindsBy(How = How.Id, Using = "_eEe")]
        public IWebElement TextField { get; set; }


        //---------- A C T I O N S ----------//


        //Verify Text field
        public void VerifyTextField(string text)
        {
            Assert.IsTrue(TextField.Text.Contains(text));
        }
    }
}
