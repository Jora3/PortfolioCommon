using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class SocialNetworkRepository : Repository<SocialNetwork>, ISocialNetworkRepository
    {
        public SocialNetworkRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
