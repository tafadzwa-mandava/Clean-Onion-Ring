using Core.Entities;
using System;
using Xunit;

namespace UnitTests.Core.EntitiesTests
{
    public class AddProduct
    {
        private string _name = "Peaches";
        private int _quantity = 2;

        private string _imageUrl = "";
        private DateTime _datePosted = DateTime.Now.AddDays(1);
        private DateTime? _expiryDate = DateTime.Now.AddDays(1);
        private DateTime _productionDate = DateTime.Now.AddDays(1);
        private double _markedPrice = 100;

        [Fact]
        public void AddsProductIfNotPresent()
        {
            /*
            var product = new Product(_name, _quantity, _imageUrl, _datePosted, _expiryDate, _productionDate, _markedPrice);
            Assert.Equal(_name, product.Name);
            Assert.Equal(_quantity, product.Name);
            Assert.Equal(_imageUrl, product.Name);
            Assert.Equal(_datePosted, product.Name);
            Assert.Equal(_expiryDate, product.Name);
            Assert.Equal(_productionDate, product.Name);
            Assert.Equal(_markedPrice, product.Name);
            */
        }
    }
}
