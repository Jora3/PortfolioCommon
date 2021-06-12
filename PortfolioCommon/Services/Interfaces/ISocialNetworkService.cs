using PortfolioCommon.Data.Entities;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Interfaces
{
    public interface ISocialNetworkService
    {
        void Update(int id, string label, string link, string logo);
        SocialNetwork Get(int id);
        void Remove(int id);
        void Add(string label, string link, string logoPath);
        IList<SocialNetwork> GetAll();
    }
}
