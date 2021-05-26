using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class WorkItem : Entity
    {
        public virtual WorkType WorkType { get; set; }

        [Required(ErrorMessage = "Le nom du projet est requis.")]
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "La photo représentant le projet est requise.")]
        public string PathPhoto { get; set; }
    }
}
