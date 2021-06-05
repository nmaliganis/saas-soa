using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Answers;

namespace soa.repository.ContractRepositories
{
    public interface IAnswerRepository : IRepository<Answer, int>
    {
        int FindCountTotals();
        Answer FindAnswerByNumPlate(string numPlate);
    }
}