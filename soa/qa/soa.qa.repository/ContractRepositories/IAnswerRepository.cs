using System.Collections.Generic;
using soa.common.infrastructure.Domain;
using soa.qa.model.Answers;

namespace soa.qa.repository.ContractRepositories
{
    public interface IAnswerRepository : IRepository<Answer, int>
    {
        int FindCountTotals();
        IList<Answer> FindAnswersByQuestionId(int questionId);
    }
}