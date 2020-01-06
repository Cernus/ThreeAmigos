using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeAmigos.CustomerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeAmigos.CustomerApp.Models;
using ThreeAmigos.CustomerFacade;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace ThreeAmigos.CustomerAppTests.Services
{
    [TestClass()]
    public class CustomerFacTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void CreateOrderTest()
        {
            // Arrange
            OrderDto orderDto = new OrderDto
            {
                ProductId = 1,
                Quantity = 5,
                TimeOrdered = DateTime.Now
            };

            // Act
            OrderService.CreateOrder(orderDto);
        }

        [TestMethod()]
        public void TestGetCustomer()
        {
            // Arrange
            int customerId = 2;

            Customer expectedCustomer = (new Customer
            {
                Username = "Admin",
                Password = "password",
                FirstName = "Joe",
                SecondName = "Bloggs",
                Address = "49 Balsham Road,Harrold,MK53 5XZ",
                EmailAddress = "johndoe@gmail.com",
                Tel = "07015234278",
                Sell_To = true
            });

            string expectedResult = JsonConvert.SerializeObject(expectedCustomer);

            // Act
            CustomerFac customerFac = new CustomerFac();
            string result = customerFac.GetCustomer(customerId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void TestGetCustomerUpdate()
        {
            // Arrange
            int customerId = 2;

            CustomerUpdateDto expectedCustomer = (new CustomerUpdateDto
            {
                Username = "Admin",
                Password = "password",
                FirstName = "Joe",
                SecondName = "Bloggs",
                Address = "49 Balsham Road,Harrold,MK53 5XZ",
                EmailAddress = "johndoe@gmail.com",
                Tel = "07015234278",
            });

            string expectedResult = JsonConvert.SerializeObject(expectedCustomer);

            // Act
            CustomerFac customerFac = new CustomerFac();
            string result = customerFac.GetCustomerUpdate(customerId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void TestGetCustomerName()
        {
            // Arrange
            int customerId = 2;

            string expectedResult = "Admin";

            // Act
            CustomerFac customerFac = new CustomerFac();
            string result = customerFac.GetCustomerName(customerId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void TestHasAddressAndTel()
        {
            // Arrange
            int customerId = 2;
            bool expectedResult = true;

            // Act
            CustomerFac customerFac = new CustomerFac();
            bool result = customerFac.HasDeliveryDetails(customerId);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void TestAuthenticate()
        {
            // Arrange
            string username = "Admin";
            string password = "password";

            int expectedResult = 2;

            // Act
            CustomerFac customerFac = new CustomerFac();
            int result = customerFac.Authenticate(username, password);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        //[TestMethod()]
        //public void TestUpdateCustomer()
        //{
        //    // Arrange
        //    int customerId = 2;
        //    string json = "{ \"Username\":\"Admin\",\"Password\":\"password\",\"FirstName\":\"Joe\",\"SecondName\":\"Bloggs\",\"Address\":\"49 Balsham Road,Harrold,MK53 5XZ\",\"EmailAddress\":\"johndoe@gmail.com\",\"Tel\":\"07015234278\"}";
        //    HttpResponseMessage expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

        //    // Act
        //    CustomerFac customerFac = new CustomerFac();
        //    HttpResponseMessage result = customerFac.UpdateCustomer(customerId, json);

        //    // Assert
        //}
    }
}