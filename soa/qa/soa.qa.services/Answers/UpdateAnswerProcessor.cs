using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Answers;
using soa.qa.contracts.Answers;
using soa.qa.model.Answers;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Answers
{
  public class UpdateAnswerProcessor : IUpdateAnswerProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IAnswerRepository _answerRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdateAnswerProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IAnswerRepository answerRepository)
    {
      _uOf = uOf;
      _answerRepository = answerRepository;
      _autoMapper = autoMapper;
    }


    private void MakeAnswerPersistent(Answer answerToBeMadePersistence)
    {
      _answerRepository.Save(answerToBeMadePersistence);
      _uOf.Commit();
    }

    public Task<AnswerUiModel> UpdateAnswerAsync(int idAnswerToBeUpdated, AnswerForModificationUiModel updatedAnswer)
    {
      throw new NotImplementedException();
    }
  }
}
