using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NavigationTests
{
    public class Navigate
    {

        IWebDriver driver = new ChromeDriver("C:\\Users\\Laura\\Documents");

        [OneTimeSetUp]
        public void Setup()
        {
            //run chrome in background.
          

            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            driver.Manage().Window.Maximize();

            //login
            IWebElement loginInput = driver.FindElement(By.Id("username"));
            loginInput.SendKeys("admin@admin.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Admin123!");
            loginInput.SendKeys(Keys.Return);
        }



        [Test]
        public void NavigatetoHome()
        {
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            string TitleHome = driver.Title;
            Assert.AreEqual(TitleHome, "Home Page - OnlineShop2022");
        }


        [Test]
        public void NavigatetoBrowse()
        {

            
            driver.FindElement(By.Id("browse")).Click();
            string Title = driver.Title;
            Assert.AreEqual(Title, "Products Page");
            Thread.Sleep(5000);
            
        }


        [TearDown]
        public void End()
        {
            driver.Close();

        }



    }

}
