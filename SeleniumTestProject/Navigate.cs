using com.sun.org.apache.xalan.@internal.xsltc;
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

        //Works, but sleneium doesn't seem to update changes. Still comes up as privacy when on manual test it definitely isnt. No ids, titles or tags left behind to cause this.
        [Test]
        public void NavigatetoBrowse()
        {

            
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[1]")).Click();
            string Title = driver.Title;
            Assert.AreEqual(Title, "Products Page - OnlineShop2022");
            Thread.Sleep(5000);
            
        }

        //Navigate to profile - bit buggy, doesn't find the element half the time no matter what method is used. However, does work and pass the test.
        ///html/body/header/nav/div/div/ul/li[2]/a
        ///parent /html/body/header/nav/div/div/ul/li[2]
        [Test] 
        public void NavigatetoProfile()
        {
            driver.FindElement(By.Id("manage")).Click();
            string Title = driver.Title;
            Assert.AreEqual(Title, "Profile - OnlineShop2022");
            Thread.Sleep(5000);

        }

        //navigate to admin menu functions

    

        //navigate to manager menu functions
        [Test]
        public void NavigatesToCart()
        {


            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[2]/a")).Click();
            string Title = driver.Title;
            Assert.AreEqual(Title, "- OnlineShop2022");
            Thread.Sleep(5000);

        }

        //navigate to new product page
        [Test]
        public void NavigateToProductDetail()
        {
            String currentURL = driver.Url;
            //navigate to products
            driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[1]")).Click();
            string Title = driver.Title;
            Assert.AreEqual(Title, "Products Page - OnlineShop2022");
            Thread.Sleep(5000);
            //press view
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a[2]")).Click();
            //assert url matches seeded product

            if (currentURL != "https://onlineshoptest.azurewebsites.net/Home/ProductDetail/2")
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

        [Test]
        public void NavigateToReview()
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

            //check url matches leave review route
            if (currentURL != "https://onlineshoptest.azurewebsites.net/Review/Create?data=2")
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
