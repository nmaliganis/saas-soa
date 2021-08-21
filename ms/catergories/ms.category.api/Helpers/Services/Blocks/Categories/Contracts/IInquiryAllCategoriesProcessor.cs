using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Categories;

namespace ms.category.api.Helpers.Services.Blocks.Categories.Contracts
{
    public interface IInquiryAllCategoriesProcessor
    {
      Task<List<CategoryUiModel>> GetCategoriesAsync();
    }
}