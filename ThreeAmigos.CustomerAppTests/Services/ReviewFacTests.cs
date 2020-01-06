using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeAmigos.ReviewFacade;

namespace ThreeAmigos.CustomerAppTests.Services
{
    [TestClass]
    public class ReviewFacTests
    {
        [TestMethod]
        public void TestGetCustomerReviews()
        {
            // Arrange
            int customerId = 2;
            string expectedResult = "[{\"Rating\":0,\"Description\":\"string\",\"ProductId\":5,\"CustomerId\":2},{\"Rating\":3,\"Description\":\"Three-star review\",\"ProductId\":0,\"CustomerId\":2},{\"Rating\":4,\"Description\":\"Product Id Review\",\"ProductId\":3,\"CustomerId\":2},{\"Rating\":3,\"Description\":\"Review Product 3\",\"ProductId\":3,\"CustomerId\":2}]";

            // Act
            ReviewFac reviewFac = new ReviewFac();
            string result = reviewFac.GetCustomerReviews(customerId);

            // Assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void TestGetProductReviews()
        {
            // Arrange
            int productId = 3;

            ReviewFac reviewFac = new ReviewFac();
            string expectedNotNull = reviewFac.GetProductReviews(productId);

            // Assert
            Assert.IsNotNull(expectedNotNull);
        }

        [TestMethod]
        public void TestGetWrittenReviewsIds()
        {
            // Arrange
            int customerId = 2;
            List<int> expectedResult = new List<int> { 5, 0, 3, 3 };

            // Act
            ReviewFac reviewFac = new ReviewFac();
            List<int> result = reviewFac.GetWrittenReviewsIds(customerId);

            // Assert
            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }
    }
}
