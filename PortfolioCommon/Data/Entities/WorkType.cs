using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class WorkType : Entity
    {
        [Required(ErrorMessage = "Le code dy type de travail est requis.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Le libellé dy type de travail est requis.")]
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
