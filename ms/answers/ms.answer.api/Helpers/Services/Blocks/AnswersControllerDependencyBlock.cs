using ms.answer.api.Helpers.Services.Blocks.Answers.Contracts;

namespace ms.answer.api.Helpers.Services.Blocks
{
    public class AnswersControllerDependencyBlock : IAnswersControllerDependencyBlock
    {
        public AnswersControllerDependencyBlock(ICreateAnswerProcessor createAnswerProcessor,
                                                        IInquiryAnswerProcessor inquiryAnswerProcessor,
                                                        IUpdateAnswerProcessor updateAnswerProcessor,
                                                        IInquiryAllAnswersProcessor allAnswerProcessor,
                                                        IDeleteAnswerProcessor deleteAnswerProcessor)

        {
            CreateAnswerProcessor = createAnswerProcessor;
            InquiryAnswerProcessor = inquiryAnswerProcessor;
            UpdateAnswerProcessor = updateAnswerProcessor;
            InquiryAllAnswersProcessor = allAnswerProcessor;
            DeleteAnswerProcessor = deleteAnswerProcessor;
        }

        public ICreateAnswerProcessor CreateAnswerProcessor { get; private set; }
        public IInquiryAnswerProcessor InquiryAnswerProcessor { get; private set; }
        public IUpdateAnswerProcessor UpdateAnswerProcessor { get; private set; }
        public IInquiryAllAnswersProcessor InquiryAllAnswersProcessor { get; private set; }
        public IDeleteAnswerProcessor DeleteAnswerProcessor { get; private set; }
    }
}