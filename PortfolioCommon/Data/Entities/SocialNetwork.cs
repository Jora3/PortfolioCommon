using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class SocialNetwork : Entity
    {
        [Required(ErrorMessage = "Le libellé du réseau social est requis.")]
        public string Label { get; set; }

        [Required(ErrorMessage = "Le logo du réseau social est requis.")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Le lien vers le réseau social est requis.")]
        public string Link { get; set; }
    }
}
