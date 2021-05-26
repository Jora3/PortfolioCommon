using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
