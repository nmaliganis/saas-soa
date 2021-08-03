using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;
using soa.common.infrastructure.TypeMappings;
using soa.statistics.api.Helpers.Repositories;
using soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts;

namespace soa.statistics.api.Helpers.Services.Blocks.Statistics.Impls
{
    public class InquiryAllStatisticsProcessor : IInquiryAllStatisticsProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IStatisticRepository _statisticRepository;

        public InquiryAllStatisticsProcessor(IAutoMapper autoMapper, IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
            _autoMapper = autoMapper;
        }

        public Task<List<StatisticUiModel>> GetStatisticsAsync()
        {
            return Task.Run(() => _statisticRepository.FindAll().Select(x => _autoMapper.Map<StatisticUiModel>(x)).ToList());
        }
    }
}