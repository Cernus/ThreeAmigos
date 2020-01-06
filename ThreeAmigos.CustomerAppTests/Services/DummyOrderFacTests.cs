using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ThreeAmigos.OrderFacade;
using ThreeAmigos.OrderFacade.Models;

namespace ThreeAmigos.CustomerAppTests.Services
{
    [TestClass]
    public class DummyOrderFacTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestCreateOrder()
        {
            // Arrange
            string json = "{\"ProductId\":13,\"Quantity\":1,\"TimeOrdered\":\"2020 - 01 - 06T00: 00:00 + 00:00\"}";

            // Act
            DummyOrder dummyOrder = new DummyOrder();
            dummyOrder.CreateOrder(json);

            // Assert
        }

        [TestMethod]
        public void TestGetInvoices()
        {
            // Arrange
            int customerId = 2;
            List<Invoice> invoices = GetInvoices();
            string expectedResult = JsonConvert.SerializeObject(invoices);

            // Act
            DummyOrder dummyOrder = new DummyOrder();
            string result = dummyOrder.GetInvoices(customerId);


            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        private List<Invoice> GetInvoices()

        {
            List<Invoice> invoices = new List<Invoice>();

            var products1 = new List<ProductOrder>();
            var products2 = new List<ProductOrder>();
            var products3 = new List<ProductOrder>();

            // Add Product to products lists
            products1.Add(new ProductOrder()
            {
                ProductId = 1,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 0
            });

            products1.Add(new ProductOrder()
            {
                ProductId = 2,
                TotalPrice = 0,
                Quantity = 1,
                OrderId = 0
            });

            products1.Add(new ProductOrder()
            {
                ProductId = 3,
                TotalPrice = 0,
                Quantity = 99,
                OrderId = 0
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 2,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 1
            });

            products2.Add(new ProductOrder()
            {
                ProductId = 1,
                TotalPrice = 0,
                Quantity = 1,
                OrderId = 1
            });

            products3.Add(new ProductOrder()
            {
                ProductId = 3,
                TotalPrice = 0,
                Quantity = 3,
                OrderId = 2
            });

            // Make Invoices
            invoices.Add(new Invoice()
            {
                OrderId = 0,
                Reference = "ref1",
                Status = "Pending",
                Products = products1,
                OrderDate = new DateTime(2019, 10, 10).ToShortDateString(),
                InvoiceCost = 0
            });

            invoices.Add(new Invoice()
            {
                OrderId = 1,
                Reference = "ref2",
                Status = "Cancelled",
                Products = products2,
                OrderDate = new DateTime(2019, 10, 11).ToShortDateString(),
                InvoiceCost = 0
            });

            invoices.Add(new Invoice()
            {
                OrderId = 2,
                Reference = "ref3",
                Status = "Delivered",
                Products = products3,
                OrderDate = new DateTime(2019, 10, 12).ToShortDateString(),
                InvoiceCost = 0
            });

            return invoices;
        }
    }
}
