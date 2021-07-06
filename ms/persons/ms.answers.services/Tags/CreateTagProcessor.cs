using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Tags;
using soa.contracts.Tags;
using soa.repository.ContractRepositories;

namespace soa.services.Tags
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
