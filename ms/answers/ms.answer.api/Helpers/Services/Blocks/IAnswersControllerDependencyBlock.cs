using soa.qa.contracts.Answers;

namespace soa.qa.contracts.V1
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