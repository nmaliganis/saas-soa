using soa.qa.contracts.Questions;

namespace soa.qa.contracts.V1
{
  public interface IQuestionsControllerDependencyBlock
  {
    ICreateQuestionProcessor CreateQuestionProcessor { get; }
    IInquiryQuestionProcessor InquiryQuestionProcessor { get; }
    IUpdateQuestionProcessor UpdateQuestionProcessor { get; }
    IInquiryAllQuestionsProcessor InquiryAllQuestionsProcessor { get; }
    IDeleteQuestionProcessor DeleteQuestionProcessor { get; }
  }
}