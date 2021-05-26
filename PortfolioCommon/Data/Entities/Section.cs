using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class Section : Entity
    {
        [Required(ErrorMessage = "La référence de la section est requise pour la liaison avec le menu.")]
        public string Ref { get; set; }

        [Required(ErrorMessage = "Le titre de la section est requis.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string PathPhoto { get; set; }
    }
}
