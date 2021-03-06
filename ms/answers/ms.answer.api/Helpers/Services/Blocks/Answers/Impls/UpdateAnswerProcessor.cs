using System;
using System.Threading.Tasks;
using ms.answer.api.Helpers.Models;
using ms.answer.api.Helpers.Repositories;
using ms.answer.api.Helpers.Services.Blocks.Answers.Contracts;
using soa.common.dtos.Vms.Answers;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace ms.answer.api.Helpers.Services.Blocks.Answers.Impls
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
