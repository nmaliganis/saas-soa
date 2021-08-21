using ms.tag.api.Helpers.Services.Blocks.Tags.Contracts;

namespace ms.tag.api.Helpers.Services.Blocks.Tags
{
  /// <summary>
  /// 
  /// </summary>
  public interface ITagsControllerDependencyBlock
  {
    ICreateTagProcessor CreateTagProcessor { get; }
    IInquiryTagProcessor InquiryTagProcessor { get; }
    IUpdateTagProcessor UpdateTagProcessor { get; }
    IInquiryAllTagsProcessor InquiryAllTagsProcessor { get; }
    IDeleteTagProcessor DeleteTagProcessor { get; }
  }
}