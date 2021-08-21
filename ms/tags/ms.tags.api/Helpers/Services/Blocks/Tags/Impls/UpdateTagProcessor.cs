using System;
using System.Threading.Tasks;
using ms.tag.api.Helpers.Models;
using ms.tag.api.Helpers.Repositories;
using ms.tag.api.Helpers.Services.Blocks.Tags.Contracts;
using soa.common.dtos.Vms.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace ms.tag.api.Helpers.Services.Blocks.Tags.Impls
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
