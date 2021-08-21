using ms.answer.api.Helpers.Models;
using soa.common.infrastructure.Domain;

namespace ms.answer.api.Helpers.Repositories
{
    public interface IAnswerRepository : IRepository<Answer, int>
    {
        int FindCountTotals();
        Answer FindAnswerByTitle(string title);
    }
}