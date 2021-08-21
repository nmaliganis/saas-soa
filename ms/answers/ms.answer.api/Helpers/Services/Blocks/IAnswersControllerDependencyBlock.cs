using ms.answer.api.Helpers.Services.Blocks.Answers.Contracts;

namespace ms.answer.api.Helpers.Services.Blocks
{
  public interface IAnswersControllerDependencyBlock
  {
    ICreateAnswerProcessor CreateAnswerProcessor { get; }
    IInquiryAnswerProcessor InquiryAnswerProcessor { get; }
    IUpdateAnswerProcessor UpdateAnswerProcessor { get; }
    IInquiryAllAnswersProcessor InquiryAllAnswersProcessor { get; }
    IDeleteAnswerProcessor DeleteAnswerProcessor { get; }
  }
}