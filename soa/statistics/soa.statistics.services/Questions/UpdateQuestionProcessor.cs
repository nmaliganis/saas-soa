using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Questions;
using soa.contracts.Questions;
using soa.model.Questions;
using soa.repository.ContractRepositories;

namespace soa.services.Questions
{
  public class UpdateQuestionProcessor : IUpdateQuestionProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdateQuestionProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IQuestionRepository questionRepository)
    {
      _uOf = uOf;
      _questionRepository = questionRepository;
      _autoMapper = autoMapper;
    }


    private void MakeQuestionPersistent(Question questionToBeMadePersistence)
    {
      _questionRepository.Save(questionToBeMadePersistence);
      _uOf.Commit();
    }

    public Task<QuestionUiModel> UpdateQuestionAsync(int idQuestionToBeUpdated, QuestionForModificationUiModel updatedQuestion)
    {
      throw new NotImplementedException();
    }
  }
}
