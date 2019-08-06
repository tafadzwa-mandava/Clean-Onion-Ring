using Core.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class SampleProductCategoryData
    {

        private static SampleProductCategoryData _instance;

        public static SampleProductCategoryData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SampleProductCategoryData();
                return _instance;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return new List<Category>()
                {

                    new Category()
                    {
                        Name = "Fruits and vegetables",
                        Code = "100",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Apples",
                                BarCode = "001010010101010101",
                                Quantity = 5,
                                ImageUrl = "",
                                DatePosted = DateTime.Now.AddDays(-7),
                                ExpiryDate = DateTime.Now.AddMonths(10),
                                ProductionDate = DateTime.Now.AddYears(-1),
                                MarkedPrice = 100

                            }, 
                            new Product()
                            {
                                Name = "Spinach",
                                BarCode = "0010100111101010101",
                                Quantity = 2,
                                ImageUrl = "",
                                DatePosted = DateTime.Now.AddDays(-7),
                                ExpiryDate = DateTime.Now.AddDays(10),
                                ProductionDate = DateTime.Now.AddDays(-10),
                                MarkedPrice = 100
                            },
                            new Product()
                            {
                                Name = "Bananas",
                                BarCode = "001010111101010101",
                                Quantity = 2,
                                ImageUrl = "",
                                DatePosted = DateTime.Now.AddDays(-7),
                                ExpiryDate = DateTime.Now.AddDays(10),
                                ProductionDate = DateTime.Now.AddDays(-10),
                                MarkedPrice = 100
                            }
                        }
                    },
                    new Category()
                    {
                        Name = "Detergent",
                        Code = "101",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Bleach",
                                BarCode = "001010111101010101",
                                Quantity = 2,
                                ImageUrl = "",
                                DatePosted = DateTime.Now.AddDays(-7),
                                ExpiryDate = DateTime.Now.AddDays(10),
                                ProductionDate = DateTime.Now.AddDays(-10),
                                MarkedPrice = 100
                            },
                            new Product()
                            {
                                Name = "Washing Powder",
                                BarCode = "001010111101010101",
                                Quantity = 2,
                                ImageUrl = "",
                                DatePosted = DateTime.Now.AddDays(-7),
                                ExpiryDate = DateTime.Now.AddDays(10),
                                ProductionDate = DateTime.Now.AddDays(-10),
                                MarkedPrice = 100
                            }
                        }
                    }

                };
            }
        }


    }
}
