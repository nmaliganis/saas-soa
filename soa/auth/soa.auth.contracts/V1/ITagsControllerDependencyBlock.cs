using soa.contracts.Tags;

namespace soa.contracts.V1
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