using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
