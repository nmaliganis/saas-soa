using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Answers;

namespace soa.repository.ContractRepositories
{
    public interface IAnswerRepository : IRepository<Answer, int>
    {
        QueryResult<Answer> FindAllAnswersPagedOf(int? pageNum = -1, int? pageSize = -1);
        int FindCountTotals();
        Answer FindAnswerByNumPlate(string numPlate);
    }
}