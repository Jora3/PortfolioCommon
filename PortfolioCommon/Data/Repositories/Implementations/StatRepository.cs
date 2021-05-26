using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class StatRepository : Repository<Stat>, IStatRepository
    {
        public StatRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
