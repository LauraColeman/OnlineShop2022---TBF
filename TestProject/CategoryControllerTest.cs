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
        private ILogger<ShoppingCartController> _logger;
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
        public async void CategoryControllerSuccessfulCreation()
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


        [Fact] //Test to check existing categories can be deleted from db.
        public async void CategoryDeleteControllerSuccessful()
        {
            //Arrange - Create database, dummy data and controller.
            CreateMockDB();
            var controller = new CategoryController(_db);
            var newCats = new CategoryModel() { Id = 2, Name = "New test dummy product" };

            _db.Categories.Add(newCats);
            _db.SaveChanges();
            //Act - Test to delete existing category.
            var result = await controller.DeleteConfirmed(newCats.Id);

            //Assert - Check the category no longer exists
            Assert.NotNull(result);
            Assert.DoesNotContain(newCats, _db.Categories);
        }

        [Fact]

        public async void GetCategoryDetailsSuccessful()
        {
            //Arrange - Create mock database and add dummy data
            CreateMockDB();
            var dummyCat1 = new CategoryModel() { Id = 1, Name = "Test Data 1" };
            var dummyCat2 = new CategoryModel() { Id = 2, Name = "Test Data 2" };

            _db.Categories.Add(dummyCat1);
            _db.Categories.Add(dummyCat2);
            _db.SaveChanges();

            //Act  - Assessable variable - Render database categories into a text list
            var result = await _db.Categories.ToListAsync();

            //Assert - Check the list is not null
            Assert.NotNull(result);
        }

        [Fact] //Test to check existing categories can be edited through the controller
        public async void CategoryControllerCreateDuplicateError()
        {
            //Arrange - Create mock database and add dummy data
            CreateMockDB();
            var controller = new CategoryController(_db);
            var dummyCat1 = new CategoryModel() { Id = 1, Name = "Test Data 1" };
            var dummyCat2 = new CategoryModel() { Id = 1, Name = "Test Data 2 id test" };


            _db.Categories.Add(dummyCat1);
            
            _db.SaveChanges();

            //Act  - Test to access edit view.
            var result = await controller.Create(dummyCat2);

            //Assert - Return edit view to pass. See Selenium EditTests for editing functionality.

            Assert.NotNull(result);
        }

    }

}