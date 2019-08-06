using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class ProductNotFoundException: Exception
    {
        public ProductNotFoundException(int productId)
             : base($"No product found with id {productId}")
        {
        }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
