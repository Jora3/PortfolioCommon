using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class ReferenceItemRepository : Repository<ReferenceItem>, IReferenceItemRepository
    {
        public ReferenceItemRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
