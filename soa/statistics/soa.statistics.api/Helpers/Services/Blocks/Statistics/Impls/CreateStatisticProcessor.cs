using System.Threading.Tasks;
using soa.common.dtos.Vms.Statistics;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Statistics;
using soa.statistics.api.Helpers.Repositories;

namespace soa.statistics.api.Helpers.Services.Blocks.Statistics.Impls
{
    public class CreateStatisticProcessor : ICreateStatisticProcessor
    {
        private readonly IUnitOfWork _uOf;
        private readonly IStatisticRepository _StatisticRepository;
        private readonly IAutoMapper _autoMapper;

        public CreateStatisticProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
            IStatisticRepository StatisticRepository)
        {
            _uOf = uOf;
            _StatisticRepository = StatisticRepository;
            _autoMapper = autoMapper;
        }

        public Task<StatisticUiModel> CreateStatisticAsync(StatisticForCreationUiModel newStatisticUiModel)
        {
            return null;
        }
    }
}