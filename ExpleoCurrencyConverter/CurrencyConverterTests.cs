using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace ExpleoCurrencyConverter
{
    [AllureNUnit]
    public class CurrencyConversionTests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {   
            //Create new Chrome Browser driver and set window to max
            ChromeOptions Options = new ChromeOptions();
            Options.AddArgument("--start-maximized");
            driver = new ChromeDriver(Options);
            action = new Actions(driver);
        }

        [Test]
        public void CurrencyConversions()
        {
            driver.Navigate().GoToUrl("https://www.xe.com/currencyconverter/");
            CurrencyControl GetCurrency = new CurrencyControl();

            CurrencyControl.AmountSelection("10");
            CurrencyControl.CurrencyFromSelection("EUR");
            CurrencyControl.CurrencyToSelection("USD");
            double USD = GetCurrency.GetUSDValue();
            double USDFinal = GetCurrency.CalculateCurrency("USD", USD, 10);
            string USDCurrencyCalculated = Convert.ToString(USDFinal);    
            CurrencyControl.ConvertCurrency();
            string ConvertedUSD = GetCurrency.GetCalculatedCurrency();
            Assert.True(ConvertedUSD.Contains(USDCurrencyCalculated));
            Assert.True(ConvertedUSD.Contains("US Dollars"));

            driver.Navigate().GoToUrl("https://www.xe.com/currencyconverter/");
            CurrencyControl.AmountSelectionAfterClear("20");
            CurrencyControl.CurrencyFromSelection("EUR");
            CurrencyControl.CurrencyToSelection("GBP");
            double GBP = GetCurrency.GetGBPValue();
            double GBPFinal = GetCurrency.CalculateCurrency("GBP", GBP, 20);
            string GBPCurrencyCalculated = Convert.ToString(GBPFinal);
            CurrencyControl.ConvertCurrency();
            string ConvertedGBP = GetCurrency.GetCalculatedCurrency();
            Assert.True(ConvertedGBP.Contains(GBPCurrencyCalculated));
            Assert.True(ConvertedGBP.Contains("British Pounds"));

            driver.Navigate().GoToUrl("https://www.xe.com/currencyconverter/");
            CurrencyControl.AmountSelectionAfterClear("4");
            CurrencyControl.CurrencyFromSelection("EUR");
            CurrencyControl.CurrencyToSelection("YEN");
            double YEN = GetCurrency.GetYENValue();
            double YENFinal = GetCurrency.CalculateCurrency("YEN", YEN, 4);
            string YENCurrencyCalculated = Convert.ToString(YENFinal);
            CurrencyControl.ConvertCurrency();
            string ConvertedYEN = GetCurrency.GetCalculatedCurrency();

            Console.WriteLine("ConvertedYEN: " +ConvertedYEN);
            Console.WriteLine("YENCurrencyCalculated: " + YENCurrencyCalculated);

            Assert.True(ConvertedYEN.Contains(YENCurrencyCalculated));
            Assert.True(ConvertedYEN.Contains("Japanese Yen"));

            driver.Navigate().GoToUrl("https://www.xe.com/currencyconverter/");
            CurrencyControl.AmountSelectionAfterClear("25");
            CurrencyControl.CurrencyFromSelection("EUR");
            CurrencyControl.CurrencyToSelection("CAD");
            double CAD = GetCurrency.GetCADValue();
            double CADFinal = GetCurrency.CalculateCurrency("CAD", CAD, 25);
            string CADCurrencyCalculated = Convert.ToString(CADFinal);
            CurrencyControl.ConvertCurrency();
            string ConvertedCAD = GetCurrency.GetCalculatedCurrency();
            Assert.True(ConvertedCAD.Contains(CADCurrencyCalculated));
            Assert.True(ConvertedCAD.Contains("Canadian Dollars"));

            driver.Navigate().GoToUrl("https://www.xe.com/currencyconverter/");
            CurrencyControl.AmountSelectionAfterClear("50");
            CurrencyControl.CurrencyFromSelection("USD");
            CurrencyControl.CurrencyToSelection("GBP");
            GBP = GetCurrency.GetGBPValue();
            GBPFinal = GetCurrency.CalculateCurrency("GBP", GBP, 50);
            GBPCurrencyCalculated = Convert.ToString(GBPFinal);
            CurrencyControl.ConvertCurrency();
            ConvertedGBP = GetCurrency.GetCalculatedCurrency();
            Assert.True(ConvertedGBP.Contains(GBPCurrencyCalculated));
            Assert.True(ConvertedGBP.Contains("British Pounds"));
        }
    }
}