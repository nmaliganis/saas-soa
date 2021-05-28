using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Persons;
using soa.contracts.Persons;
using soa.model.Persons;
using soa.repository.ContractRepositories;

namespace soa.services.Persons
{
  public class UpdatePersonProcessor : IUpdatePersonProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IPersonRepository _personRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdatePersonProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IPersonRepository personRepository)
    {
      _uOf = uOf;
      _personRepository = personRepository;
      _autoMapper = autoMapper;
    }


    private void MakePersonPersistent(Person personToBeMadePersistence)
    {
      _personRepository.Save(personToBeMadePersistence);
      _uOf.Commit();
    }

    public Task<PersonUiModel> UpdatePersonAsync(int idPersonToBeUpdated, PersonForModificationUiModel updatedPerson)
    {
      throw new NotImplementedException();
    }
  }
}
