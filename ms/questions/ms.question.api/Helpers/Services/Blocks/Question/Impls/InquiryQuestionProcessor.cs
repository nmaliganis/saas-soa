using System;
using System.Threading.Tasks;
using ms.question.api.Helpers.Repositories;
using ms.question.api.Helpers.Services.Blocks.Question.Contracts;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.TypeMappings;

namespace ms.question.api.Helpers.Services.Blocks.Question.Impls
{
    public class InquiryQuestionProcessor : IInquiryQuestionProcessor
    {
      private readonly IAutoMapper _autoMapper;
      private readonly IQuestionRepository _questionRepository;

      public InquiryQuestionProcessor(IAutoMapper autoMapper,
        IQuestionRepository questionRepository)
      {
        _autoMapper = autoMapper;
        _questionRepository = questionRepository;
      }
        public Task<QuestionUiModel> GetQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetQuestionCountTotalsAsync()
        {
          return Task.Run(() => _questionRepository.FindCountTotals());
        }

        public Task<QuestionUiModel> GetQuestionByIdAsync(int id)
        {
          return Task.Run(() =>_autoMapper.Map<QuestionUiModel>(_questionRepository.FindBy(id)));
        }

        public Task<QuestionUiModel> GetQuestionByTitleAsync(string title)
        {
          return Task.Run(() =>_autoMapper.Map<QuestionUiModel>(_questionRepository.FindQuestionByTitle(title)));
        }
    }
}
