using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
