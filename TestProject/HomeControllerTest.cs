using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Areas.Admin;
using OnlineShop2022.Controllers;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace TestProject
{

   
    public class HomeControllerTest
    {
        



        //needs to be given a mock database - dont want to effect real data.
        private ILogger<HomeController> _logger;
        private AppDbContext _db;
        


        private void CreateMockDB()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            //create database
            _db = new AppDbContext(options);

            //ensure creation and return
            _db.Database.EnsureCreated();
            
        }

        [Fact]
        public void HomeControllerIndexNotNull()
        {
            //3 As for unit tests.
            //Arrange - prepare data and things to be used.
                    //needs logger, and database.
            var controller = new HomeController(_logger, _db);

            //Act - Perform Tests.
            var result = controller.Index();

            //Assert - Check Results.
            Assert.NotNull(result);


        }

        [Fact]
        public void HomeControllerPrivacyNotNull()
        {
            //3 As for unit tests.
            //Arrange - prepare data and things to be used.
            //needs logger, and database.
            var controller = new HomeController(_logger, _db);

            //Act - Perform Tests.
            var result = controller.Privacy();

            //Assert - Check Results.
            Assert.NotNull(result);


        }
        
       


        [Fact] //Retrieve products inside the Home Controller
        public async void HomeControllerListProducts()
        {
            //Arrange - Create mock database and add dummy data
            CreateMockDB();
            var dummyProduct1 = new ProductModel() { Id = 1, Description = "Test Data 1" };
            var dummyProduct2 = new ProductModel() { Id = 2, Description = "Test Data 2" };

            //Act  - Assessable variable - Render database products into a text list
            var result = await _db.Products.ToListAsync(); 

            //Assert - Check the list is not null
            Assert.NotNull(result);
        }






    }
}
