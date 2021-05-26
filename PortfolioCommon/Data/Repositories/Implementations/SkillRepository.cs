using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Infrastructure;
using PortfolioCommon.Data.Repositories.Interfaces;

namespace PortfolioCommon.Data.Repositories.Implementations
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(PortfolioContext portfolioContext) : base(portfolioContext)
        {
        }
    }
}
