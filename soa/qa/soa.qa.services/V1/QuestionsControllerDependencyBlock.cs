﻿using soa.qa.contracts.Questions;
using soa.qa.contracts.V1;

namespace soa.services.V1
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