using Microsoft.EntityFrameworkCore;
using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;
using System.Linq;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class WorkItemRepository : Repository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }

        public override WorkItem ReadOne(int id)
        {
            return _portfolioContext.WorkItems
                .Include(w => w.WorkType)
                .FirstOrDefault(w => w.Id == id);
        }
    }
}
