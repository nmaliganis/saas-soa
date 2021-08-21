using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Tags;
using soa.qa.model.Tags;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Tags
{
  public class UpdateTagProcessor : IUpdateTagProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ITagRepository _tagRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdateTagProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, ITagRepository tagRepository)
    {
      _uOf = uOf;
      _tagRepository = tagRepository;
      _autoMapper = autoMapper;
    }


    private void MakeTagPersistent(Tag tagToBeMadePersistence)
    {
      _tagRepository.Save(tagToBeMadePersistence);
      _uOf.Commit();
    }

    public Task<TagUiModel> UpdateTagAsync(int idTagToBeUpdated, TagForModificationUiModel updatedTag)
    {
      throw new NotImplementedException();
    }
  }
}
