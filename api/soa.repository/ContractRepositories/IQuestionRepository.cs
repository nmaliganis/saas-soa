using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Questions;

namespace soa.repository.ContractRepositories
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        QueryResult<Question> FindAllQuestionsPagedOf(int? pageNum = -1, int? pageSize = -1);
        int FindCountTotals();
        Question FindQuestionByNumPlate(string numPlate);
    }
}