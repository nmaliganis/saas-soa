using System;

namespace soa.common.infrastructure.Exceptions.Domain.Tags
{
    public class TagDoesNotExistException : Exception
    {
        public int TagId { get; }

        public TagDoesNotExistException(int tagId)
        {
            TagId = tagId;
        }

        public override string Message => $"Tag with Id:" +
                                          $" {TagId}  doesn't exists!";
    }
}
