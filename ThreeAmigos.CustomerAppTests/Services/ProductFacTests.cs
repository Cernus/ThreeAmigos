using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ThreeAmigos.ProductFacade;
using ThreeAmigos.ProductFacade.Models;

namespace ThreeAmigos.CustomerAppTests.Services
{
    // TODO: Add Tests that are expected to fail. E.g. GetProduct(id = 0) - does not exist

    [TestClass]
    public class ProductFacTests
    {
        [TestMethod]
        public void TestGetProducts()
        {
            // Arrange

            // Act
            ProductFac productFac = new ProductFac();
            string expectedNotNull = productFac.GetProducts();

            // Assert
            Assert.IsNotNull(expectedNotNull);
        }

        [TestMethod]
        public void TestGetProductsFromCustomerApi()
        {
            // Arrange

            // Act
            ProductFac productFac = new ProductFac();
            string expectedNotNull = productFac.GetProductsFromCustomerApi();

            // Assert
            Assert.IsNotNull(expectedNotNull);
        }

        [TestMethod]
        public void TestGetProduct()
        {
            // Arrange
            int productId = 1;

            ProductDto product = (new ProductDto
            {
                Id = 1,
                Name = "Wrap It and Hope Cover",
                CategoryName = "Covers",
                BrandName = "Soggy Sponge",
                Description = "Poor quality fake faux leather cover loose enough to fit any mobile device.",
                Price = 5.99,
                StockLevel = 1
            });

            string expectedResult = JsonConvert.SerializeObject(product);

            // Act
            ProductFac productFac = new ProductFac();
            string result = productFac.GetProduct(productId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestGetProductName()
        {
            // Arrange
            int productId = 1;
            string expectedResult = "Wrap It and Hope Cover";

            // Act
            ProductFac productFac = new ProductFac();
            string result = productFac.GetProductName(productId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestInStock()
        {
            // Arrange
            int productId = 2;
            int quantity = 99999;
            bool expectedResult = false;

            // Act
            ProductFac productFac = new ProductFac();
            bool result = productFac.InStock(productId, quantity);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
