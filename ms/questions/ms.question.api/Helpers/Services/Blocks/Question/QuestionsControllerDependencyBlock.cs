using ms.question.api.Helpers.Services.Blocks.Question.Contracts;

namespace ms.question.api.Helpers.Services.Blocks.Question
{
    public class QuestionsControllerDependencyBlock : IQuestionsControllerDependencyBlock
    {
        public QuestionsControllerDependencyBlock(ICreateQuestionProcessor createQuestionProcessor,
                                                        IInquiryQuestionProcessor inquiryQuestionProcessor,
                                                        IUpdateQuestionProcessor updateQuestionProcessor,
                                                        IInquiryAllQuestionsProcessor allQuestionProcessor,
                                                        IDeleteQuestionProcessor deleteQuestionProcessor)

        {
            CreateQuestionProcessor = createQuestionProcessor;
            InquiryQuestionProcessor = inquiryQuestionProcessor;
            UpdateQuestionProcessor = updateQuestionProcessor;
            InquiryAllQuestionsProcessor = allQuestionProcessor;
            DeleteQuestionProcessor = deleteQuestionProcessor;
        }

        public ICreateQuestionProcessor CreateQuestionProcessor { get; private set; }
        public IInquiryQuestionProcessor InquiryQuestionProcessor { get; private set; }
        public IUpdateQuestionProcessor UpdateQuestionProcessor { get; private set; }
        public IInquiryAllQuestionsProcessor InquiryAllQuestionsProcessor { get; private set; }
        public IDeleteQuestionProcessor DeleteQuestionProcessor { get; private set; }
    }
}