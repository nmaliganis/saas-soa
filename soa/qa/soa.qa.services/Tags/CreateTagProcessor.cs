﻿using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Tags;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Tags
{
  public class CreateTagProcessor : ICreateTagProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ITagRepository _tagRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateTagProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      ITagRepository tagRepository)
    {
      _uOf = uOf;
      _tagRepository = tagRepository;
      _autoMapper = autoMapper;
    }

    public Task<TagUiModel> CreateTagAsync(TagForCreationUiModel newTagUiModel)
    {
      return null;
    }
  }
}
