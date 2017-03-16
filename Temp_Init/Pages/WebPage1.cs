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

        //Country combo box
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div[3]/div")]
        public IWebElement CountryCombo { get; set; }

        //City field
        [FindsBy(How = How.Id, Using = "edit_city")]
        public IWebElement City { get; set; }

        //Address field
        [FindsBy(How = How.Id, Using = "edit_address")]
        public IWebElement Address { get; set; }

        //Field        
        [FindsBy(How = How.Id, Using = "edit_address")]
        public IWebElement Field { get; set; }

        //Switch
        [FindsBy(How = How.XPath, Using = ".//*[@id='hide-customer']/div[4]/div[2]/label")]
        public IWebElement Switch { get; set; }


        //Panel
        [FindsBy(How = How.ClassName, Using = "panel")]
        public IWebElement Panel { get; set; }

        //Options button
        [FindsBy(How = How.Id, Using = "customer_options")]
        public IWebElement OptionsBtn { get; set; }

        //Delete button        
        [FindsBy(How = How.CssSelector, Using = ".button.delete-button")]
        public IWebElement DeleteBtn { get; set; }

        //Confirm button
        [FindsBy(How = How.PartialLinkText, Using = "Delete")]
        public IWebElement ConfirmBtn { get; set; }


        //Confirm button
        [FindsBy(How = How.Id, Using = "amount")]
        public IWebElement AmountField { get; set; }

        //Test Text
        [FindsBy(How = How.Id, Using = "_eEe")]
        public IWebElement TextField { get; set; }


        //---------- A C T I O N S ----------//

        //Edit customer address - USING VARIABLE XPath
        public void OpenEditCustomerAddress(string account)
        {
            Driver.FindElement(By.XPath(".//*[@id='customer_table']/table/tbody/tr[td/text()=" + account + "]/td/form/input[4]")).Click();
        }

        //Populate customer address
        public void PopulateAddress(string country, string city, string address)
        {
            SelectElement countryCombo = new SelectElement(CountryCombo);

            countryCombo.SelectByText(country);
            City.Clear();
            City.SendKeys(city);
            Address.Clear();
            Address.SendKeys(address);
            Address.SendKeys(Keys.Enter);
            Driver.Navigate().Refresh();
        }

        //Populate Field
        public void PopulateField(string value)
        {
            Field.Clear();
            Field.SendKeys(value);
        }

        //Set switch to value
        public void SetSwitch(string value)
        {
            if (!Switch.Text.Contains(value))
            {
                Switch.Click();
            }
        }

        //Do action while condition exists
        public void DeleteAllCustomers(string text)
        {
            while (!Panel.Text.Contains(text))
            {
                OptionsBtn.Click();
                DeleteBtn.Click();
                ConfirmBtn.Click();
                Thread.Sleep(TimeSpan.FromSeconds(15));
            }
        }


        //Get string from a field and convert to decimal
        public string amountString;
        public decimal amountDecimal
        {
            get
            {
                string amountString = AmountField.Text.Replace("£", string.Empty).Replace("*", string.Empty).Replace(" ", string.Empty);
                return Convert.ToDecimal(amountString);
            }
        }

        public string amount1String;
        public decimal amount1Decimal
        {
            get
            {
                string amountString = AmountField.Text.Replace("£", string.Empty).Replace("*", string.Empty).Replace(" ", string.Empty);
                return Convert.ToDecimal(amount1String);
            }
        }

        public string amount2String;
        public decimal amount2Decimal
        {
            get
            {
                string amountString = AmountField.Text.Replace("£", string.Empty).Replace("*", string.Empty).Replace(" ", string.Empty);
                return Convert.ToDecimal(amount2String);
            }
        }

        //Verify calculation
        public void VerifyCalculation()
        {
            Assert.IsTrue(amountDecimal.Equals(amount1Decimal + amount2Decimal), "Calculation is not correct");
        }

        //Verify calculation with parameters
        public void VerifyCalculationParameters(decimal value, decimal value1, decimal value2)
        {
            Assert.IsTrue(value.Equals(value1 + value2), "Calculation is not correct");
        }

        //Verify Text field
        public void VerifyTextField(string text)
        {
            Assert.IsTrue(TextField.Text.Contains(text));
        }
    }
}
