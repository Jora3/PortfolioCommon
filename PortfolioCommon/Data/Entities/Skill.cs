using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class Skill : Entity
    {
        [Required(ErrorMessage = "L'intitulé de la compétence est requis.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La largeur de la barre de compétence est requise.")]
        public string Width { get; set; }

        [Required(ErrorMessage = "La valeur actuelle de la barre de compétence est requise.")]
        public int ValueNow { get; set; }

        [Required(ErrorMessage = "La valeur minimum de la barre de compétence est requise.")]
        public int ValueMin { get; set; }

        [Required(ErrorMessage = "La valeur maximum de la barre de compétence est requise.")]
        public int ValueMax { get; set; }
    }
}
