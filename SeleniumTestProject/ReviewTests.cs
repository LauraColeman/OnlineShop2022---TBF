using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public  class ReviewTests
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
        public void LeaveReviewSuccess()
        {

            String currentURL = driver.Url;
            //navigate to products
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[1]")).Click();
            string Title = driver.Title;
            Assert.AreEqual(Title, "Products Page - OnlineShop2022");
            Thread.Sleep(5000);
            //press view
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a[2]")).Click();
            //press leave review
            driver.FindElement(By.XPath("/html/body/div/main/a[2]")).Click();
            //input review data
            IWebElement titleInput = driver.FindElement(By.XPath("//*[@id='Title']"));
            titleInput.SendKeys("TestReview");
            IWebElement bodyInput = driver.FindElement(By.XPath("//*[@id='Body']"));
            bodyInput.SendKeys("Test Review. Very Good!");
            IWebElement ratInput = driver.FindElement(By.XPath("//*[@id='Rating']"));
            ratInput.SendKeys("2");
            //submit
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div/button")).Click();
            //check user is redirected back to the product page
            if (currentURL != "https://onlineshoptest.azurewebsites.net/ProductDetail/5")
            {
                Assert.Fail();
                End();
            }

            else
            {
                Assert.Pass();
                End();
            }

        }


        [TearDown]
        public void End()
        {
            driver.Close();

        }


    }
}
