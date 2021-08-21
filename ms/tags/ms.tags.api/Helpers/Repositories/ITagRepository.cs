using ms.tag.api.Helpers.Models;
using soa.common.infrastructure.Domain;

namespace ms.tag.api.Helpers.Repositories
{
    public interface ITagRepository : IRepository<Tag, int>
    {
        int FindCountTotals();
        Tag FindTagByTitle(string title);
    }
}