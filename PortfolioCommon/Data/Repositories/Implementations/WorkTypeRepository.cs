using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class WorkTypeRepository : Repository<WorkType>, IWorkTypeRepository
    {
        public WorkTypeRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
