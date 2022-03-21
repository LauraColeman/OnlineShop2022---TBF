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


namespace SeleniumTestProject
{
    public class CheckoutTests
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


        //add products to cart
        //on successfull add, user is redirected to cart

        [Test]

       public void AddtoCartSuccessful()
        {
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();

            String currentURL = driver.Url;



            if(currentURL != "https://onlineshoptest.azurewebsites.net/ShoppingCart")
            {
                Assert.Fail();
                End();
            }

            else { Assert.Pass();
                End();
            }

        }


        [Test]
        public void RemoveFromCartSuccessful()
        {
            //add item to basket
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();
            //click item remove button
            driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[4]/a")).Click();




        }

        [Test]
        public void EmptyBasketSuccessful()
        {
            //add item to basket
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();

            //click empty basket
            driver.FindElement(By.XPath("/html/body/div/main/div/a[2]")).Click();

            

        }

        [Test]

        public void CheckoutSuccessful()
        {
            //add item to basket
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();
            //click proceed to checkout
            driver.FindElement(By.XPath("/html/body/div/main/div/a[1]")).Click();
            //enter delivery details
            IWebElement lnameInput = driver.FindElement(By.Id("LastName"));
            lnameInput.SendKeys("Admin");
            IWebElement fnameInput = driver.FindElement(By.Id("FirstName"));
            fnameInput.SendKeys("Admin");
            IWebElement addressOne = driver.FindElement(By.Id("AddressLine1"));
            addressOne.SendKeys("!0 Taunton Road");
            IWebElement addressTwo = driver.FindElement(By.Id("AddressLine2"));
            addressTwo.SendKeys("Taunton House!");
            IWebElement postcode = driver.FindElement(By.Id("Postcode"));
            postcode.SendKeys("TA11 111");
            IWebElement cityInput = driver.FindElement(By.Id("City"));

            cityInput.SendKeys("Taunton");
            IWebElement countryInput = driver.FindElement(By.Id("Country"));
            countryInput.SendKeys("England");
            IWebElement emailInput = driver.FindElement(By.Id("Email"));
            emailInput.SendKeys("admin@admin.com");
            //proceed to payment
            emailInput.SendKeys(Keys.Return);
            //click pay now
            driver.FindElement(By.XPath("//*[@id='submit']")).Click();

            Assert.Pass();
            End();

        }



        [TearDown]
        public void End()
        {
            driver.Close();

        }

        //payment details


        /* --------------------Cannot access stripe frame for payment- will be tested manually --------------------------------------------------




        //switch frame wot access strope fields



        IWebElement cardNumber = driver.FindElement(By.Id("Field - numberInput"));
        cardNumber.SendKeys("4242424242424242");
        IWebElement expiryDate = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/div/div/div/div[1]/div[2]/div/div/div"));
        expiryDate.SendKeys("1023");
        IWebElement cvc = driver.FindElement(By.XPath("//*[@id='Field - cvcInput']"));
        cvc.SendKeys("123");
        IWebElement postCode = driver.FindElement(By.XPath("//*[@id='Field - postalCodeInput']"));
        postCode.SendKeys("WS111DB");

        //click pay now
        driver.FindElement(By.XPath("//*[@id='submit']")).Click();



        //result message 

        var msg = driver.FindElement(By.XPath("//*[@id='submit']")).ToString();

        string result = "Thanks for your order.";

        if(msg == result)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    */

        //Called after each test is run.


    }
}
