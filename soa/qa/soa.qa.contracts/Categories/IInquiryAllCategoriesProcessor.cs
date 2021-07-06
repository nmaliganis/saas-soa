using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Categories;

namespace soa.qa.contracts.Categories
{
    public interface IInquiryAllCategoriesProcessor
    {
      Task<List<CategoryUiModel>> GetCategoriesAsync();
    }
}