using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;
using soa.common.infrastructure.TypeMappings;
using soa.statistics.api.Helpers.Repositories;
using soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts;

namespace soa.statistics.api.Helpers.Services.Blocks.Statistics.Impls
{
    public class InquiryStatisticProcessor : IInquiryStatisticProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IStatisticRepository _StatisticRepository;

        public InquiryStatisticProcessor(IAutoMapper autoMapper,
            IStatisticRepository StatisticRepository)
        {
            _autoMapper = autoMapper;
            _StatisticRepository = StatisticRepository;
        }


        public Task<int> GetStatisticCountTotalsAsync()
        {
            return Task.Run(() => _StatisticRepository.FindCountTotals());
        }

        public Task<StatisticUiModel> GetStatisticByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StatisticUiModel> GetStatisticByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }
    }
}