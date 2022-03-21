using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AuthenticationTests
{
    public class LogInTests
    {
        IWebDriver driver = new ChromeDriver("C:\\Users\\Laura\\Documents");

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            driver.Manage().Window.Maximize();
        }



      

  
        //register route works
        [Test]
        public void RegisterButtonOnHomePage()
        {
            driver.FindElement(By.Id("register")).Click();
            Thread.Sleep(5000);
        }

        //register new user

        [Test]
        public void RegisterNewUser()
        {
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net/Identity/Account/Register?returnUrl=%2F");


            IWebElement fnameInput = driver.FindElement(By.Id("fname"));
            fnameInput.SendKeys("Test");
            IWebElement snameInput = driver.FindElement(By.Id("sname"));
            snameInput.SendKeys("Test");
            IWebElement emailInput = driver.FindElement(By.Id("email"));
            emailInput.SendKeys("admins@admins.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Admin123!");
            IWebElement passwInput = driver.FindElement(By.Id("confirmPass"));
            passInput.SendKeys("Admin123!");
            IWebElement confirmReg = driver.FindElement(By.Id("confirmReg"));
            confirmReg.SendKeys(Keys.Return);

           
        }



        [Test]

        public void MenuRestrictedToAdmin()
        {
            //Checking eleemnts that should be disabled are. Restricted buttons on user role should be null.
            IWebElement adminButton = null;
            IWebElement managerButton = null;

            //login as admin user
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            IWebElement loginInput = driver.FindElement(By.Id("username"));
            loginInput.SendKeys("admin@admin.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Admin123!");
            loginInput.SendKeys(Keys.Return);
            //click browse button
           adminButton = driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]"));
           managerButton = driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]"));

            if (adminButton == null || managerButton == null)
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

        public void MenuRestrictedToManager()
        {
            //Checking eleemnts that should be disabled are. Restricted buttons on user role should be null.
            IWebElement adminButton = null;
            IWebElement managerButton = null;

            //login as admin user
            driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
            IWebElement loginInput = driver.FindElement(By.Id("username"));
            loginInput.SendKeys("man@man.com");
            IWebElement passInput = driver.FindElement(By.Id("password"));
            passInput.SendKeys("Manager123!");
            loginInput.SendKeys(Keys.Return);
            //click browse button

            if (adminButton != null && managerButton == null)
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

            public void MenuRestrictedToUser()
            {
                //Checking eleemnts that should be disabled are. Restricted buttons on user role should be null.
                IWebElement adminButton = null;
                IWebElement managerButton = null;

                //login as admin user
                driver.Navigate().GoToUrl("https://onlineshoptest.azurewebsites.net");
                IWebElement loginInput = driver.FindElement(By.Id("username"));
                loginInput.SendKeys("user@user.com");
                IWebElement passInput = driver.FindElement(By.Id("password"));
                passInput.SendKeys("User123!!");
                loginInput.SendKeys(Keys.Return);
                //click browse button
                try
                {
                    adminButton = driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[3]"));
                }
                catch { }

                try
                {
                    managerButton = driver.FindElement(By.XPath("//html/body/header/nav/div/div/ul/li[4]"));
                }
                catch { }

                if (adminButton != null || managerButton != null)
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


        //logout

        //Called after each test is run.
        [TearDown]
        public void End()
        {
            driver.Close();

        }




    }
}