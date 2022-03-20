using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Areas.Admin;
using OnlineShop2022.Controllers;
using OnlineShop2022.Data;
using OnlineShop2022.Helpers;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class CategoryControllerTest
    {
        //needs to be given a mock database - dont want to effect real data.
        //private ILogger<ProductController> _logger;
        private AppDbContext _db;
        private Images _images;
        private IWebHostEnvironment _webHostEnvironment;






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

        [Fact] //Test to check the Index area of the Category Controller is not null
        public void CategoryControllerIndexNotNull()
        {
            //Arrange - Mock database and controller
            CreateMockDB();
            var controller = new CategoryController(_db);

            //Act - Access the controllers index
            var result = controller.Index();

            //Assert - Check value is not null to pass.
            Assert.NotNull(result);
        }


        [Fact] //Testing ability to add new category to database.
        public async void CategoryControllerCreateSuccessful()
        {
            //Arrange - Create the mock database and instance of controller to access methods.
            CreateMockDB();
            var controller = new CategoryController(_db);

            //Sets details of the category to be created
            var newCat = new CategoryModel() { Id = 50, Name = "New test dummy product" };

            //Act - Result of creation test.
            var result = await controller.Create(newCat);

            //Assert - Check new category has been added to the db.
            Assert.NotNull(result);
            Assert.Contains(newCat, _db.Categories);
        }

    }

}