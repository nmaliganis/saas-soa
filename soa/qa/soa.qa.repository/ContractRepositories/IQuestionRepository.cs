using System.Collections.Generic;
using soa.common.infrastructure.Domain;
using soa.qa.model.Questions;

namespace soa.qa.repository.ContractRepositories
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        int FindCountTotals();
        int FindUnansweredCountTotals();
        Question FindQuestionByTitle(string title);
        IList<Question> FindAllByToday();
        IList<Question> FindAllByUnanswered();
    }
}