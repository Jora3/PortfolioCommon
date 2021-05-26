using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class ReferenceItem : Entity
    {
        [Required(ErrorMessage = "Le contenu de la référence est requis.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Le nom du référenceur est requis.")]
        public string ReferencerName { get; set; }
        public string ReferencerFunction { get; set; }
        public string ReferencerPhoto { get; set; }
    }
}
