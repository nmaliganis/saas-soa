using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Questions;

namespace soa.repository.ContractRepositories
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        int FindCountTotals();
        Question FindQuestionByTitle(string title);
    }
}