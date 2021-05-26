using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class Menu : Entity
    {
        [Required(ErrorMessage = "Le libellé du menu est requis.")]
        public string Label { get; set; }

        [Required(ErrorMessage = "L'attribut href du menu est requis.")]
        public string Href { get; set; }
    }
}
