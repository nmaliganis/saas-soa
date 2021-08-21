using ms.tag.api.Helpers.Services.Blocks.Tags.Contracts;

namespace ms.tag.api.Helpers.Services.Blocks.Tags
{
    public class TagsControllerDependencyBlock : ITagsControllerDependencyBlock
    {
        public TagsControllerDependencyBlock(ICreateTagProcessor createTagProcessor,
                                                        IInquiryTagProcessor inquiryTagProcessor,
                                                        IUpdateTagProcessor updateTagProcessor,
                                                        IInquiryAllTagsProcessor allTagProcessor,
                                                        IDeleteTagProcessor deleteTagProcessor)

        {
            CreateTagProcessor = createTagProcessor;
            InquiryTagProcessor = inquiryTagProcessor;
            UpdateTagProcessor = updateTagProcessor;
            InquiryAllTagsProcessor = allTagProcessor;
            DeleteTagProcessor = deleteTagProcessor;
        }

        public ICreateTagProcessor CreateTagProcessor { get; private set; }
        public IInquiryTagProcessor InquiryTagProcessor { get; private set; }
        public IUpdateTagProcessor UpdateTagProcessor { get; private set; }
        public IInquiryAllTagsProcessor InquiryAllTagsProcessor { get; private set; }
        public IDeleteTagProcessor DeleteTagProcessor { get; private set; }
    }
}