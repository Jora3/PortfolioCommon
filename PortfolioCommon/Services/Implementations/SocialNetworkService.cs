using PortfolioCommon.Data.Entities;
using PortfolioCommon.Data.Repositories.Interfaces;
using PortfolioCommon.Services.Helpers;
using PortfolioCommon.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PortfolioCommon.Services.Implementations
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private readonly ISocialNetworkRepository _socialNetworkRepository;

        public SocialNetworkService(ISocialNetworkRepository socialNetworkRepository)
        {
            _socialNetworkRepository = socialNetworkRepository;
        }

        public void Update(int id, string label, string link, string logo)
        {
            CheckLabel(label);
            CheckLink(link);
            CheckLogo(logo);

            var socialNetwork = Get(id);
            if (socialNetwork != null)
            {
                label = label.Trim();
                link = link.Trim();
                logo = logo.Trim();

                CheckLabelExist(socialNetwork, label);
                CheckLinkExist(socialNetwork, link);
                CheckLogoExist(socialNetwork, logo);

                socialNetwork.Label = label;
                socialNetwork.Link = link;
                socialNetwork.Logo = logo;

                _socialNetworkRepository.Update(socialNetwork);
            }
            else
                throw new Exception("Aucun réseau ne correspond à l'ID renseigné.");
        }

        public SocialNetwork Get(int id)
        {
            return _socialNetworkRepository.ReadOne(id);
        }

        public void Remove(int id)
        {
            _socialNetworkRepository.Delete(id);
        }

        public void Add(string label, string link, string logo)
        {
            CheckLabel(label);
            CheckLink(link);
            CheckLogo(logo);
            CheckLabelExist(null, label);
            CheckLinkExist(null, link);
            CheckLogoExist(null, logo);

            _socialNetworkRepository.Create(new SocialNetwork
            {
                Label = label.Trim(),
                Link = link.Trim(),
                Logo = logo
            });
        }

        public IList<SocialNetwork> GetAll()
        {
            return _socialNetworkRepository.ReadAll();
        }

        private void CheckLinkExist(SocialNetwork socialNetwork, string link)
        {
            if (socialNetwork == null || link.ToLower() != socialNetwork.Link.ToLower())
            {
                if (_socialNetworkRepository.ReadOne(_ => _.Link.ToLower().Equals(link.ToLower())) != null)
                    throw new Exception("Un réseau avec ce lien existe déjà.");
            }
        }

        private void CheckLogoExist(SocialNetwork socialNetwork, string logo)
        {
            if (socialNetwork == null || logo.ToLower() != socialNetwork.Logo.ToLower())
            {
                if (_socialNetworkRepository.ReadOne(_ => _.Logo.ToLower().Equals(logo.ToLower())) != null)
                    throw new Exception("Un réseau avec ce logo existe déjà.");
            }
        }

        private void CheckLabelExist(SocialNetwork socialNetwork, string label)
        {
            if (socialNetwork == null || label.ToLower() != socialNetwork.Label.ToLower())
            {
                if (_socialNetworkRepository.ReadOne(_ => _.Label.ToLower().Equals(label.ToLower())) != null)
                    throw new Exception("Un réseau avec ce libellé existe déjà.");
            }
        }

        private static void CheckLogo(string logo)
        {
            if (string.IsNullOrEmpty(logo.Trim()))
                throw new Exception("Le logo du réseau est vide ou n'a pas été renseigné.");
        }

        private static void CheckLink(string link)
        {
            if (string.IsNullOrEmpty(link.Trim()))
                throw new Exception("Le lien du réseau est vide ou n'a pas été renseigné.");
            if (!UriHelper.IsValidUrl(link))
                throw new Exception("Le lien du réseau n'est pas valide.");
        }

        private static void CheckLabel(string label)
        {
            if (string.IsNullOrEmpty(label.Trim()))
                throw new Exception("Le libellé du réseau est vide ou n'a pas été renseigné.");
        }
    }
}
