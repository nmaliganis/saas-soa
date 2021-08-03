using soa.qa.contracts.Tags;

namespace soa.qa.contracts.V1
{
  public interface ITagsControllerDependencyBlock
  {
    ICreateTagProcessor CreateTagProcessor { get; }
    IInquiryTagProcessor InquiryTagProcessor { get; }
    IUpdateTagProcessor UpdateTagProcessor { get; }
    IInquiryAllTagsProcessor InquiryAllTagsProcessor { get; }
    IDeleteTagProcessor DeleteTagProcessor { get; }
  }
}