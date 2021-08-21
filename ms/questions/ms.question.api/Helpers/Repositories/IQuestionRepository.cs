using ms.question.api.Helpers.Models;
using soa.common.infrastructure.Domain;

namespace ms.question.api.Helpers.Repositories
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        int FindCountTotals();
        Question FindQuestionByTitle(string title);
    }
}