using soa.contracts.Answers;

namespace soa.contracts.V1
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