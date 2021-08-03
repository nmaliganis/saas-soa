using FluentNHibernate.Mapping;
using soa.qa.model.Tags;
using soa.statistics.api.Helpers.Models;

namespace soa.statistics.api.Helpers.Repositories.Mappings
{
    public class StatisticMap : ClassMap<Statistic>
    {
        public StatisticMap()
        {
            Schema(@"public");
            Table(@"Statistics");
            LazyLoad();

            Id(x => x.Id)
                .Column("id")
                .CustomType("int")
                .Access.Property()
                .Not.Nullable()
                .GeneratedBy
                .Increment()
                ;

            Map(x => x.Body)
                .Column("`body`")
                .CustomType("string")
                .Unique()
                .Access.Property()
                .Generated.Never()
                .Not.Nullable()
                ;
        }
    }
}