using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Controllers;
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
    public class ShoppingCartControllerTest
    {

        //needs to be given a mock database - dont want to effect real data.
        private ILogger<ShoppingCartController> _logger;
        private AppDbContext _db;

        private IProductRepository _ProductRepository;
        private ShoppingCartModel _ShoppingCart;



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



        private void CreateRepo() //Instatiates funcions needed for database editing
        {
            _ProductRepository = new ProductRepository(_db);
            _ShoppingCart = new ShoppingCartModel(_db);
        }

        
        [Fact] //Test to check new products can be added to the shopping cart
        private void ShoppingCartAddToCartSuccessful()
        {
            //Arrange - Creates database. Uses repository and shopping cart needed by the Controller to manipulate cart. Item list to check items are added (can compare count).
            CreateMockDB();
            CreateRepo();
            ShoppingCartController controller = new ShoppingCartController(_ProductRepository, _ShoppingCart);
            


            //New product to be added to shopping car and controlled by controller functions.
            var addProd = new ProductModel() { Id = 3, Description = "New Dummy Product", Price = 10 };
         


            _db.Products.Add(addProd);
            _db.SaveChanges();

            //Act - New shopping cart created after adding a product
            controller.AddToShoppingCart(addProd.Id);
            _db.Products.ToList();

            _ShoppingCart.AddToCart(addProd, 1);

            var newShopCart = _ShoppingCart.GetShoppingCartItems();

            //Assert- Check product count in the Cart has increased by 1.

           // Assert.Equal(items.Count, newShopCart.Count);
            Assert.Equal(newShopCart.Count, 1);

        }


        [Fact] //Test to check multiple items of the same products can be added to the user's shopping cart
        private void AddMultipleQuanitityToCartSuccessful()

        {
            //Arrange - Creates database. Uses repository and shopping cart needed by the Controller to manipulate cart. Item list to check items are added (can compare count).
            CreateMockDB();
            CreateRepo();
            ShoppingCartController controller = new ShoppingCartController(_ProductRepository, _ShoppingCart);



            //New product to be added to shopping car and controlled by controller functions.
            var addProd = new ProductModel() { Id = 3, Description = "New Dummy Product", Price = 10 };



            _db.Products.Add(addProd);
            _db.SaveChanges();

            //Act - New shopping cart created after adding a product
            controller.AddToShoppingCart(addProd.Id);
            _db.Products.ToList();

            _ShoppingCart.AddToCart(addProd, 3);

            var newShopCart = _ShoppingCart.GetShoppingCartItems();

            //Assert- Check product count in the Cart has increased by 1.

            
            Assert.Equal(newShopCart.Count, 1);

        }


        [Fact]
        private void RemoveFromShoppingCartSuccessful() //Remove items from cart
        {
            //Arrange - Creates database. Uses repository and shopping cart needed by the Controller to manipulate cart. Item list to check items are added (can compare count).
            CreateMockDB();
            CreateRepo();
            ShoppingCartController controller = new ShoppingCartController(_ProductRepository, _ShoppingCart);



            //New product to be added to shopping car and controlled by controller functions.
            var addProd = new ProductModel() { Id = 3, Description = "New Dummy Product", Price = 10 };
            _db.Products.Add(addProd);
            _db.SaveChanges();

            //Act - New shopping cart created after adding a product
            //add product to cart to be removed
            controller.AddToShoppingCart(addProd.Id);
            _db.Products.ToList();

            //remove from cart
            _ShoppingCart.RemoveFromCart(addProd);
            var newShopCart = _ShoppingCart.GetShoppingCartItems();

            //Assert- Check product count in the Cart has increased by 1. - Expected 0 in cart.
            Assert.Equal(newShopCart.Count, 0);
        }

        [Fact] //Test to check the total calculated from the user's shopping cart is accurate
        private async void ShoppingCartTotalIsAccurate()
        {
            //Arrange : Creates and Populates the Database, Repository and Shopping Cart needed by the Controller
            CreateMockDB();
            CreateRepo();

            ShoppingCartController controller = new ShoppingCartController(_ProductRepository, _ShoppingCart);
            //products added to list to be totalled
            var addProd = new ProductModel() { Id = 3, Description = "New Dummy Product", Price = 10 };
            var addProd2 = new ProductModel() { Id = 4, Description = "Another New Dummy Product", Price = 20 };

           

            //Act - New shopping cart created after adding a product
            controller.AddToShoppingCart(addProd.Id);
            _db.Products.ToList();

            _ShoppingCart.AddToCart(addProd, 1);
            _ShoppingCart.AddToCart(addProd2, 1);

            var newShopCart = _ShoppingCart.GetShoppingCartItems();

            //New shopping cart model to access calculation methods.
            var model = new ShoppingCartModel(_db) { ShoppingCartId = _ShoppingCart.ShoppingCartId, ShoppingCartItems = _ShoppingCart.ShoppingCartItems };

            var products = await _db.Products.ToListAsync();
            List<double> prices = new List<double>();

            //Act : Produces two variables that can be assessed - The expectedTotal variable is shows what the order total should be from the products in the cart, whilst the result variable is the outcome of the attempt to retrieve the total from the method
            foreach (var p in products) { prices.Add(p.Price); }
            var expectedTotal = prices.Sum();

            var result = model.GetShoppingCartTotal();

            //Assert : Checks that the total returned matches the expected outcome - The test will pass if the two values are equal
            Assert.Equal(expectedTotal, result);
        }



    }
}
