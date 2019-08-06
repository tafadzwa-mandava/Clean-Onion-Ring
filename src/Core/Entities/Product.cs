using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Core.Entities
{
    public class Product: TrackEntity
    {
        private Category _category;

        public Product()
        {
        }

        private Product(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Product(
            string name, 
            string barCode, 
            int quantity, 
            string imageUrl, 
            DateTime datePosted, 
            DateTime expiryDate,
            DateTime productionDate,
            double markedPrice)
        {
            Name = name;
            BarCode = barCode;
            Quantity = quantity;
            ImageUrl = imageUrl;
            DatePosted = datePosted;
            ExpiryDate = expiryDate;
            ProductionDate = productionDate;
            MarkedPrice = markedPrice;
        }

        private ILazyLoader LazyLoader { get; set; }

        public string Name { get; set; }

        public string BarCode { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public double MarkedPrice { get; set; }

        public int CategoryId { get; set; } 

        public Category Category
        {
            get => LazyLoader.Load(this, ref _category);
            set => _category = value;
        }
    }
}
