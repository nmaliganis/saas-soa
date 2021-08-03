using soa.common.infrastructure.Domain;
using soa.qa.model.Questions;

namespace soa.qa.repository.ContractRepositories
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        int FindCountTotals();
        Question FindQuestionByTitle(string title);
    }
}