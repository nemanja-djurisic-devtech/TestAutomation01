using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Temp_Init.Pages;
using Temp_Init.Data;
using NUnit.Framework;

namespace Temp_Init.Base
{
    public class Initialization
    {
        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait;

        // - Data - //
        public CsvData csvData = new CsvData();
        public DataBase dataBase = new DataBase();

        // - Pages - //
        public CommonElements commonElements;
        public WebPage1 webPage1;

        public string customer;

        public void EnvironmentSetup(string environment)
        {
            switch (environment)
            {
                case "Develop1":
                    customer = "Develop1";
                    break;

                case "Develop2":
                    customer = "Develop2";
                    break;

                case "Staging":
                    customer = "Staging";
                    break;
            }
        }

        //Definition of pages, browsers and timeouts
        public void PagesDef(string browserName)
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("--js-flags=--expose-gc");
            chromeOptions.AddArguments("--enable-precise-memory-info");
            chromeOptions.AddArguments("--disable-popup-blocking");
            chromeOptions.AddArguments("--disable-default-apps");
            chromeOptions.AddArguments("disable-infobars");
            chromeOptions.AddArguments("--disable-settings-window");

            switch (browserName)
            {
                case "Chrome":
                    Driver = new ChromeDriver(chromeOptions);
                    Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
                    Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(30));
                    Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
                    break;
                case "FireFox":
                    Driver = new FirefoxDriver();
                    break;
            }

            // - Pages - //
            commonElements = new CommonElements(Driver);
            webPage1 = new WebPage1(Driver);
        }

        //Browser commands
        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
        }

        public void CloseBrowser(IWebDriver Driver)
        {
            Driver.Quit();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
    }
}
