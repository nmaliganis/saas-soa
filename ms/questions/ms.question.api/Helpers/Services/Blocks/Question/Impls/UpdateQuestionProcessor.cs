using System;
using System.Threading.Tasks;
using ms.question.api.Helpers.Repositories;
using ms.question.api.Helpers.Services.Blocks.Question.Contracts;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace ms.question.api.Helpers.Services.Blocks.Question.Impls
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


    private void MakeQuestionPersistent(Models.Question questionToBeMadePersistence)
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
