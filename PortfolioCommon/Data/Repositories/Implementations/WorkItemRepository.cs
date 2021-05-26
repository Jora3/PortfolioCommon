using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class WorkItemRepository : Repository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
