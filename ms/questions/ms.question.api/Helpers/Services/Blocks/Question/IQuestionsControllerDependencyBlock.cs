using ms.question.api.Helpers.Services.Blocks.Question.Contracts;

namespace ms.question.api.Helpers.Services.Blocks.Question
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