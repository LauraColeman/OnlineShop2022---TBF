using Microsoft.EntityFrameworkCore;
using OnlineShop2022;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class OrderControllerTest
    {

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
        public void OrderControllerIndexNotNull()
        {
            //3 As for unit tests.
            //Arrange - prepare data and things to be used.
            OrderDetailModel orderDetailModel = new OrderDetailModel();
            orderDetailModel.Order = new OrderModel();

            var controller = new OrderController(_db);

            //Act - Perform Tests.
            var result = controller.Index();

            //Assert - Check Results.
            Assert.NotNull(result);


        }



        [Fact]
        public async void OrderCreateSuccessful()
        {

            //Arrange
            //needs images, iweb and database.
            CreateMockDB();
         
            OrderController controller = new OrderController(_db);

            var addOrder = new OrderDetailModel() { OrderDetailId = 1, OrderId = 1, ProductId = 3, Amount =1, Price=5};
            var addOrderModel = new OrderModel() { OrderId =1, FirstName = "Laura", LastName = "Coleman", AddressLine1 = "Fake House", AddressLine2 = "Fake Road", City = "Somerton", Country = "England", Email = "admin@admin.com", };

            var result = _db.OrderDetails.Add(addOrder);
            _db.SaveChanges();
            //Act 

            OrderDetailModel orderDetailModel = new OrderDetailModel();
            orderDetailModel.Order = new OrderModel();


            //Act - Result of creation test.
            var results = await controller.Create(addOrderModel);

            //Assert - Check new order has been added to the db.
            Assert.NotNull(results);
            Assert.NotNull(result);
           

        }


    }
}
