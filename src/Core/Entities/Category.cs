using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Category: BaseEntity
    {
        private ICollection<Product> _products;

        public Category()
        {
        }

        private Category(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Category(string name, string code)
        {
            Name = name;
            Code = code;       
        }

        private ILazyLoader LazyLoader { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Product> Products
        {
            get => LazyLoader.Load(this, ref _products);
            set => _products = value;
        }
    }
}
