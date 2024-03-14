using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExpleoCurrencyConverter
{
    public class CurrencyControl : DriverHelper
    {
        //Select Amount textbox and enter value
        public static void AmountSelection(string selectAmount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement amount = driver.FindElement(By.Id("amount"));
            amount.Click();
            amount.SendKeys(selectAmount);
        }

        //Select Amount textbox, clear previous values with keystrokes and then enter amount
        public static void AmountSelectionAfterClear(string selectAmount)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement amount = driver.FindElement(By.Id("amount"));
            amount.Click();
            action.SendKeys(Keys.Backspace).Build().Perform();
            action.SendKeys(Keys.Backspace).Build().Perform();
            action.SendKeys(Keys.Backspace).Build().Perform();
            amount.Click();
            action.SendKeys(Keys.Backspace).Build().Perform();
            amount.Click();
            action.SendKeys(Keys.Backspace).Build().Perform();
            amount.SendKeys(selectAmount);
        }

        //Select the currency being converted from
        public static void CurrencyFromSelection(string selectFromCurrency)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement currencyFrom = driver.FindElement(By.XPath("//*[@id=\"midmarketFromCurrency\"]/div[2]/div/input"));
            currencyFrom.Click();
            currencyFrom.SendKeys(selectFromCurrency);
            action.SendKeys(Keys.Enter).Build().Perform();
        }

        //Select the currency being converted to
        public static void CurrencyToSelection(string selectToCurrency)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement currencyTo = driver.FindElement(By.XPath("//*[@id=\"midmarketToCurrency\"]/div[2]/div/input"));
            currencyTo.Click();
            currencyTo.SendKeys(selectToCurrency);
            Thread.Sleep(1000);
            action.SendKeys(Keys.Enter).Build().Perform();
        }

        //Select the Convert button
        public static void ConvertCurrency()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement convert = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[4]/div[2]/section/div[2]/div/main/div/div[2]/button"));
            convert.Click();
        }

        //Get the conversion rate for USD on main page
        public double GetUSDValue()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var USDValue = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[4]/div[3]/section/div[1]/div[3]/div[1]/div/div[1]/div/div")).GetAttribute("outerText");                            
            double USD_Double = Convert.ToDouble(USDValue);

            return USD_Double;
        }

        //Get the conversion rate for GBP on main page
        public double GetGBPValue()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var GBPValue = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[4]/div[3]/section/div[1]/div[3]/div[2]/div/div[1]/div/div")).GetAttribute("outerText");
            double GBP_Double = Convert.ToDouble(GBPValue);

            return GBP_Double;
        }

        //Get the conversion rate for YEN on main page
        public double GetYENValue()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var YENValue = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[4]/div[3]/section/div[1]/div[3]/div[3]/div/div[1]/div/div")).GetAttribute("outerText");
            double YEN_Double = Convert.ToDouble(YENValue);

            return YEN_Double;
        }

        //Get the conversion rate for CAD on main page
        public double GetCADValue()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var CADValue = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[4]/div[3]/section/div[1]/div[3]/div[4]/div/div[1]/div/div")).GetAttribute("outerText");
            double CAD_Double = Convert.ToDouble(CADValue);

            return CAD_Double;
        }

        //Limit the conversion to 2 decimal places, or 1 decimal place if YEN
        public double CalculateCurrency(string currency, double currencyValue, int value)
        {
            double TrimmedCurrency = 0;

            if (currency != "YEN")
            {
                TrimmedCurrency = Math.Floor((currencyValue * value) * 100) / 100;
            }
            else
            {
                TrimmedCurrency = Math.Floor((currencyValue * value) * 10) / 10;
            }
            
            return TrimmedCurrency;
        }

        //Get the converted currency value after clicking convert button
        public string GetCalculatedCurrency()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var Calculated = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[4]/div[2]/section/div[2]/div/main/div/div[2]/div[1]/p[2]")).GetAttribute("outerText");
           
            return Calculated;
        }
    }
}