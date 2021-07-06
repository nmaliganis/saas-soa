using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Questions;
using soa.qa.contracts.Questions;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Questions
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
