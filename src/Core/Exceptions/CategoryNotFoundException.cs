using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class CategoryNotFoundException: Exception
    {
        public CategoryNotFoundException(int categoryId)
             : base($"No category found with id {categoryId}")
        {
        }

        protected CategoryNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CategoryNotFoundException(string message)
            : base(message)
        {
        }

        public CategoryNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
