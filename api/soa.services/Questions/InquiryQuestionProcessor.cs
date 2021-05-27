using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Questions;
using soa.contracts.Questions;
using soa.repository.ContractRepositories;

namespace soa.services.Questions
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
        public Task<QuestionUiModel> GetQuestionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetQuestionCountTotalsAsync()
        {
          return Task.Run(() => _questionRepository.FindCountTotals());
        }

        public Task<QuestionUiModel> GetQuestionByIdAsync(Guid id)
        {
          throw new NotImplementedException();
        }

        public Task<QuestionUiModel> GetQuestionByNumPlateAsync(string numPlate)
        {
          throw new NotImplementedException();
        }
    }
}
