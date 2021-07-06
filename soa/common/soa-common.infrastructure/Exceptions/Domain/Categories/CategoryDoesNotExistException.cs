using System;

namespace soa.common.infrastructure.Exceptions.Domain.Categories
{
    public class CategoryDoesNotExistException : Exception
    {
        public int CategoryId { get; }

        public CategoryDoesNotExistException(int categoryId)
        {
            CategoryId = categoryId;
        }

        public override string Message => $"Category with Id:" +
                                          $" {CategoryId}  doesn't exists!";
    }
}
